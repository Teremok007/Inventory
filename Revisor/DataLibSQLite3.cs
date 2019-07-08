using System;
using System.IO;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
//using System.Resources;

namespace BarcodeFramework
{
  public class DataLibSQLite3 : IDataLibPlugin
  {
    #region IDataLibPlugin Members
    private static string DBPath { get { return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); } }
    private static string fileExtention = ".s3db";
    protected static string dbName = "scandb";
    public string DbName { get { return dbName; } set { dbName = value; } }
    public string Datasource
    {
      get { return "Data Source='" + DBPath + "\\Data\\" + DbName + fileExtention + ";Version=3;"; }
      set { dbName = value; }
    }

     public string PluginFullName
    {
      get { return "SQLite3 Plugin"; }
    }

    private SQLiteConnection GetConnect() { return new SQLiteConnection(Datasource); } 
    public bool ConnectDatabase()
    {
      try
      {
        using (var connection = GetConnect())
        {
          connection.Open();
          connection.Close();
          return true;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }

    private int InsertOrReplace(ref OrderItem orderItem)
    {
      int rowsAffected = 0;
      string queryStr = @"INSERT OR REPLACE INTO Scan(ArtCode, id_gamma, Qty, StartDt, EndDt) 
VALUES(:ArtCode, 
       :id_gamma, 
       :Qty,
       COALESCE((SELECT StartDt FROM Scan WHERE ArtCode = :ArtCode AND id_gamma = :id_gamma), :StartDt),
       :EndDt
)";
        using (var connect = GetConnect())
        {
          connect.Open();          
          
          using (SQLiteCommand cmd = new SQLiteCommand(queryStr, connect))
          {
            cmd.Parameters.Add("ArtCode", DbType.Int32).Value = orderItem.ArtCode;
            cmd.Parameters.Add("id_gamma", DbType.Int32).Value = GlobalArea.CurrentEmployee.GammaID;
            cmd.Parameters.Add("Qty", DbType.Int32).Value = orderItem.Qty;
            cmd.Parameters.Add("StartDt", DbType.String).Value = GlobalArea.CurrentDateSQLStr;
            cmd.Parameters.Add("EndDt", DbType.String).Value = GlobalArea.CurrentDateSQLStr;
            var tx = connect.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
              rowsAffected = cmd.ExecuteNonQuery();
              tx.Commit();
            }
            catch (Exception)
            {
              tx.Rollback();
            }
          }
        }
        return rowsAffected;
    }
  
    public OrderItem Save(ref OrderItem orderItem)
    {
      int updateCount = UpdateScan(orderItem.Scan);
      if (updateCount > 0)
        try
        {
          var slog = orderItem.ScanLog;
          if (slog != null)
            SaveLog(ref slog);
        }
        catch (Exception)
        { }
      return GetOrderItemByEan(orderItem.Ean);
    }
    // обновляет orderItem | возвращает количество затронутіх записей
    public int UpdateScan(Scan scan)
    {
      string updateCommandText = @" UPDATE scan SET Qty = @qty, EndDt = @EndDt WHERE ArtCode = @artcode and id_gamma = @id_gamma ";
      int rowsAffected = 0;
      using (var connect = GetConnect())
      {
        connect.Open();
        SQLiteTransaction tx = connect.BeginTransaction();
        using (var command = connect.CreateCommand())
        {
          command.CommandText = updateCommandText;
          command.CommandType = CommandType.Text;
          command.Parameters.Add("artcode", DbType.Int32).Value = scan.ArtCode;
          command.Parameters.Add("id_gamma", DbType.Int32).Value = GlobalArea.CurrentEmployee.GammaID;
          command.Parameters.Add("qty", DbType.Int32).Value = scan.Qty;
          command.Parameters.Add("EndDt", DbType.String).Value = GlobalArea.CurrentDateSQLStr;
          command.Transaction = tx;
          try
          {
            rowsAffected = command.ExecuteNonQuery();
            tx.Commit();
          }
          catch (Exception)
          {
            tx.Rollback();
            return 0;
          }
        }
      }
      return rowsAffected;
    }
    public int ScanExport(string FileName)
    {
      string DBPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
      string fileName = DBPath + "\\" + "ScanOrders" + ".cvs";
      try
      {
        if (File.Exists(fileName))
          File.Delete(fileName);

        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
          using (StreamWriter sw = new StreamWriter(fs))
          {
            sw.WriteLine(string.Format(";Ver={0};ID_APTEKA={1};Date={2}{3}{4};DeviceID={5};Host={6}",
                                       GlobalArea.DbInfo.Version,
                                       GlobalArea.DbInfo.AptekaID.ToString(),
                                       GlobalArea.DbInfo.PereuchetDate.Year.ToString(),
                                       GlobalArea.DbInfo.PereuchetDate.Month.ToString("00"),
                                       GlobalArea.DbInfo.PereuchetDate.Day.ToString("00"),
                                       GlobalArea.DeviceInfo.DeviceID,
                                       GlobalArea.DeviceInfo.HostName));
            sw.WriteLine("#Scan");
            foreach (var item in GetAllScans())
            {
              sw.WriteLine(string.Format("{1}{0}{2}{0}{3}{0}{4}",
                                          '|',
                                          item.GammaID,
                                          item.ArtCode,
                                          item.Qty,
                                          item.EndDt));
            }
            sw.WriteLine("#ScanLog");
            foreach (var item in GetAllScansLog())
            {
              sw.WriteLine(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                                          '|',
                                          item.GammaID,
                                          item.ArtCode,
                                          item.Dt,
                                          item.Qty,
                                          item.Barcode,
                                          item.ActTypeStr
                                          ));
            }

          }
        }
      }
      catch (Exception e) { MessageBox.Show(e.Message, "Ошибка єкспорта в файл fileName", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }
      return 0;    
    }

    public Ean GetEan(string barcode)
    {
      Ean ean = null;
      string commandText = @" SELECT s.artcode, s.ean13, s.names, s.koef,  IFNULL(p.qty,0) qty, s.nds, s.Manufacturer
    FROM sprean s
    LEFT OUTER JOIN pereuchet p ON s.artcode = p.artcode 
    WHERE s.ean13 = @barcode
    ORDER BY (CASE WHEN p.qty IS NULL THEN 0 ELSE p.qty END) DESC, s.artcode desc  ";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (SQLiteCommand command = connect.CreateCommand())
        {
          command.CommandText = commandText;
          command.CommandType = CommandType.Text;
          command.Parameters.Add("barcode", DbType.String).Value = barcode;
          using (SQLiteDataReader res = command.ExecuteReader())
          {
            if (res.Read())
            {
              ean = new Ean();
              ean.ArtCode = res.GetInt32(0);
              ean.Ean13 = res.GetString(1);
              ean.Name = res.GetString(2);
              ean.Koef = res.GetInt32(3);
              ean.ControlQty = res.GetInt32(4);
              ean.Nds = res.GetInt32(5);
              ean.Manufacturer = res.GetString(6);
            }
          }
        }
      }
      return ean;
    }

    public int SprEanCount()
    {
      string commandString = "select COUNT(*) cnt from SPREAN ";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command = connect.CreateCommand())
        {
          command.CommandText = commandString;
          command.CommandType = CommandType.Text;
          return (int)command.ExecuteScalar();
        }
      }
    }

    public DbInfo GetDbInfo()
    {
      DbInfo dbInfo = new DbInfo();
      List<Ean> eans = new List<Ean>();
      string commandText = @" SELECT pName, val FROM Info ";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command = connect.CreateCommand())
        {
          command.CommandText = commandText;
          using (SQLiteDataReader res = command.ExecuteReader())
          {
            while (res.Read())
            {
                switch (res.GetString(0).ToUpper())
                {
                  case "APTEKAID":
                    dbInfo.AptekaID = res.GetString(1);
                    break;
                  case "APTEKANAME":
                    dbInfo.AptekaName = res.GetString(1);
                    break;
                  case "VERSION":
                    dbInfo.Version = res.GetString(1);
                    break;
                  case "PEREUCHETDATE":
                    long ticks = long.Parse(res.GetString(1));
                    var dt = new DateTime(ticks);
                    dbInfo.PereuchetDateText = dt.ToShortDateString();
                    dbInfo.PereuchetDate = dt;
                    break;
                  case "SPREANROWSCOUNT":
                    dbInfo.SprEanRowCountText = res.GetString(1);
                    break;
                  case "PEREUCHETROWSCOUNT":
                    dbInfo.PereuchetRowCountText = res.GetString(1);
                    break;
              }
            }
          }
        }
      }
      return dbInfo;
    }

    public OrderItem GetOrderItemByEan(Ean ean)
    {
      if (ean == null)
        return null;
      OrderItem orderItem;
      Scan scan = GetScan(ean.ArtCode);
      if (scan == null)
        return null;
      orderItem = new OrderItem(ean, scan);
      return orderItem;
    }

    public OrderItem CreateOrderItemByBarcode(string barcode)
    {
      Ean ean = GetEan(barcode);
      return (ean != null) ? CreateOrderItem(ean) : null;
    }
    public OrderItem CreateOrderItem(Ean ean)
    {
      OrderItem orderItem = null;
      string insertCommandText = @" INSERT INTO scan(ArtCode, id_gamma, Qty, Dt, StartDt, EndDt) 
VALUES(@artcode, @id_gamma, @qty, GETDATE(), @StartDt, @EndDt) ";
      using (var connect = GetConnect())
      {
        connect.Open();
        SQLiteTransaction tx = connect.BeginTransaction();
        using (SQLiteCommand command = connect.CreateCommand())
        {
          command.CommandText = insertCommandText;
          command.Parameters.Add("artcode", DbType.Int32).Value = ean.ArtCode;
          command.Parameters.Add("id_gamma", DbType.Int32).Value = GlobalArea.CurrentEmployee.GammaID;
          command.Parameters.Add("qty", DbType.Int32).Value = 0;
          command.Parameters.Add("StartDt", DbType.String).Value = GlobalArea.CurrentDateSQLStr;
          command.Parameters.Add("EndDt", DbType.String).Value = GlobalArea.CurrentDateSQLStr;
          command.Transaction = tx;
          try
          {
            int rowsAffected = command.ExecuteNonQuery();
            tx.Commit();
            orderItem = GetOrderItemByEan(ean);
          }
          catch (Exception e)
          {
            MessageBox.Show(e.Message);
            tx.Rollback();
            orderItem = null;
          }
        }
      }
      if (orderItem != null)
      {
        var slog = orderItem.ScanLog;
        SaveLog(ref slog);
      }
      return orderItem;
    }

    public OrderItem GetOrdeItemByBarcode(string barcode)
    {
      if (barcode.Length == 0)
        return null;
      Ean ean = GetEan(barcode);
      return (ean != null) ? GetOrderItemByEan(ean) : null;
    }

    public ScanInfo GetScanInfo(int IdGamma)
    {
      ScanInfo scanInfo = null;
      string countCommand = @" SELECT COUNT(*) FROM scan WHERE id_gamma = " + GlobalArea.CurrentEmployee.GammaID.ToString();
      string SumQtyCommand = @" SELECT SUM(Qty) FROM scan WHERE id_gamma = " + GlobalArea.CurrentEmployee.GammaID.ToString();
      using (var connect = GetConnect())
      {
        using (var command = connect.CreateCommand())
        {
          connect.Open();
          command.CommandText = countCommand;
          command.CommandType = CommandType.Text;
          int count = (int)command.ExecuteScalar();
          int sumQty = 0;
          if (count > 0)
          {
            command.CommandText = SumQtyCommand;
            sumQty = (int)command.ExecuteScalar();
          }
          scanInfo = new ScanInfo() { Count = count, SumQty = sumQty };
        }
        return scanInfo;
      }
    }

    public IEnumerable<Employee> GetEmployees()
    {
      string selectCommand = @" SELECT id_gamma, ename, case when barcode is not null then barcode else '' END barcode FROM Employee order by ename";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command = new SQLiteCommand(selectCommand, connect))
        {
          using (SQLiteDataReader reader = command.ExecuteReader())
          {
            if (reader != null)
            {
              try
              {
                while (reader.Read())
                {
                  yield return new Employee()
                  {
                    GammaID = (int)reader.GetInt32(reader.GetOrdinal("id_gamma")),
                    Barcode = (reader.IsDBNull(reader.GetOrdinal("barcode"))) ? "" : reader.GetString(reader.GetOrdinal("barcode")),
                    Name = reader.GetString(reader.GetOrdinal("ename"))
                  };
                }
              }
              finally
              {
                reader.Close();
              }

            }
          }
        }
      }
    }

    public Employee GetEmployee(string barcode)
    {
      Employee emp = null;
      string selectCommand = @" SELECT CONVERT(INT,id_gamma) id_gamma, ename, case when barcode is not null then barcode else '' END barcode FROM Employee WHERE barcode IS NOT NULL AND barcode = CONVERT(NVARCHAR(12), @barcode) ";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command = new SQLiteCommand(selectCommand, connect))
        {
          command.Parameters.Add("barcode", DbType.String).Value = barcode;
          using (SQLiteDataReader res = command.ExecuteReader())
          {
            if (res.Read())
            {
              emp = new Employee()
              {
                GammaID = (int)res.GetInt32(res.GetOrdinal("id_gamma")),
                Barcode = (res.IsDBNull(res.GetOrdinal("barcode"))) ? "" : res.GetString(res.GetOrdinal("barcode")),
                Name = res.GetString(res.GetOrdinal("ename"))
              };
            }
          }
        }
      }
      return emp;
    }

    public Scan GetScan(int artcode)
    {
      Scan scan = null;
      string selectCommand = @" SELECT artcode, id_gamma, qty FROM scan WHERE artcode = @artcode and id_gamma = @id_gamma";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command = connect.CreateCommand())
        {
          command.CommandText = selectCommand;
          command.Parameters.Add("artcode", DbType.Int32).Value = artcode;
          command.Parameters.Add("id_gamma", DbType.Int32).Value = GlobalArea.CurrentEmployee.GammaID;
          using (SQLiteDataReader res = command.ExecuteReader())
          {
            if (res.Read())
            {
              scan = new Scan((int)res.GetInt32(res.GetOrdinal("artcode")),
                            (int)res.GetInt32(res.GetOrdinal("id_gamma")),
                            (int)res.GetInt32(res.GetOrdinal("qty")));
            }
          }
        }
        return scan;
      }
    }

    public IEnumerable<ScanLog> GetAllScansLog()
    {
      Scan scan = null;
      string selectCommand = @" SELECT * FROM ScanLog ";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command = new SQLiteCommand(selectCommand, connect))
        {
          using (SQLiteDataReader reader = command.ExecuteReader())
          {
            if (reader != null)
            {
              while (reader.Read())
              {
                yield return new ScanLog((int)reader.GetInt32(reader.GetOrdinal("artcode")),
                                      (int)reader.GetInt32(reader.GetOrdinal("id_gamma")),
                                      (int)reader.GetInt32(reader.GetOrdinal("Qty")),
                                      (string)reader.GetString(reader.GetOrdinal("Dt")),
                                      (string)reader.GetString(reader.GetOrdinal("Barcode")),
                                      (AType)(int)reader.GetInt32(reader.GetOrdinal("ActionType")));
              }
            }
          }
        }
      }

    }

    //сохраняет лог
    public void SaveLog(ref ScanLog slog)
    {
      string insertCommandText = @" INSERT INTO ScanLog(ArtCode, id_gamma, Dt, Qty, Barcode, ActionType) 
VALUES(@artcode, @id_gamma, @Dt, @Qty, @Barcode, @ActionType) ";
      using (SQLiteConnection connect = GetConnect())
      {
        connect.Open();
        SQLiteTransaction tx = connect.BeginTransaction();
        SQLiteCommand command = connect.CreateCommand();
        command.CommandText = insertCommandText;
        command.Parameters.Add("artcode", DbType.Int32).Value = slog.ArtCode;
        command.Parameters.Add("id_gamma", DbType.Int32).Value = GlobalArea.CurrentEmployee.GammaID;
        command.Parameters.Add("Dt", DbType.String).Value = GlobalArea.CurrentDateSQLStr;
        command.Parameters.Add("Qty", DbType.Int32).Value = slog.Qty;
        command.Parameters.Add("Barcode", DbType.String).Value = slog.Barcode;
        command.Parameters.Add("ActionType", DbType.Int32).Value = (int)slog.ActType;
        command.Transaction = tx;
        try
        {
          int rowsAffected = command.ExecuteNonQuery();
          tx.Commit();
        }
        catch (Exception e)
        {
          MessageBox.Show(e.Message);
          tx.Rollback();
        }
      }
    }

    public IEnumerable<Scan> GetAllScans()
    {
      string selectCommand = @" SELECT * FROM scan ";
      using (var connect = GetConnect())
      {
        connect.Open();
        using (var command =  connect.CreateCommand())
        {
          command.CommandText = selectCommand;
          command.CommandType = CommandType.Text;
          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
                yield return new Scan((int)reader.GetInt32(reader.GetOrdinal("artcode")),
                                      (int)reader.GetInt32(reader.GetOrdinal("id_gamma")),
                                      (int)reader.GetInt32(reader.GetOrdinal("qty")))
                {
                  Dt = reader.GetDateTime(reader.GetOrdinal("dt")),
                  StartDt = reader.GetString(reader.GetOrdinal("StartDt")),
                  EndDt = reader.GetString(reader.GetOrdinal("EndDt")),
                };
            }
          }
        }
      }
    }
    #endregion
  }
}
