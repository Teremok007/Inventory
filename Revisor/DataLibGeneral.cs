using System;
using System.IO;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

namespace BarcodeFramework
{
  public class DataLibGeneral : IDataLibPlugin
  {
    //DataSet DBSet = new DataSet();
    private SqlCeConnection connect = null;
    protected ResourceManager resourceManger = new ResourceManager("BarcodeFramework.TableSchema", Assembly.GetExecutingAssembly());
    private static string fileExtention = ".sdf";
    private static string DBPath { get { return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); } }
    protected static string dbName = "scandb";
    public string DbName { get { return dbName; } set { dbName = value; } }
    public static string DbFileName = dbName + fileExtention;

    public static string DbFullName = DBPath + "\\" + DbFileName;
    public static string CreationStringDef = "Data Source='" + DbFullName + "';" + "LCID=1033;Password='admin123';Encrypt=FALSE;";
    private string ConnectionStringDef { get { return "Data Source='" + DbFullName + "'; Password=admin123;"; } }

    public string PluginFullName { get { return "SQL Server Compact 3.5 Plugin"; } }

    private bool active;
    protected string pluginPath;
    private string connectionString = CreationStringDef;
    public string Datasource
    {
      get { return "Data Source='" + DBPath + "\\" + DbName + fileExtention + "'; Password=admin123;"; }
      set { connectionString = value; }
    }
    public bool VerifyDBConnect(out string ErrorText)
    {
      ErrorText = "";
      using (SqlCeConnection connection = new SqlCeConnection(Datasource))
      {
        try
        {
          connection.Open();
          connection.Close();
        }
        catch (Exception ex)
        {
          ErrorText = "Ошибка соединениея с БД " + DbName + ".\n" + ex.Message;
          return false;
        }
        return true;
      }
    }

    private bool ConnectDatabaseTry()
    {
      try
      {
        using (SqlCeConnection connection = new SqlCeConnection(Datasource))
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
    public bool ConnectDatabase()
    {
      return ConnectDatabaseTry();
    }

    protected void ShowError(string caption, string errorText)
    {
      MessageBox.Show(errorText, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
    }

    public bool Active
    {
      get { return active; }
      set { active = value; }
    }

    
    //сохраняет одну сканированную запись в БД
    public OrderItem Save(ref OrderItem orderItem) 
    {
      int updateCount = UpdateScan(orderItem.Scan);
      return GetOrderItemByEan(orderItem.Ean);
    }
    // возвращает сканированный товар и количество по арткоду
    public OrderItem GetOrderItemByEan(Ean ean)
    {
      if (ean == null)
        return null;
      OrderItem orderItem;
      Scan scan = GetScan(ean.ArtCode);
      if (scan == null)
        return null;
      orderItem = new OrderItem(ean,scan);      
      return orderItem;
    }

    public OrderItem GetOrdeItemByBarcode(string barcode)
    {
      Ean ean = GetEan(barcode);
      return (ean != null)?GetOrderItemByEan(ean) : null;
    }
    
    // возвращает сканированный товар и количество
    public Scan GetScan(int artcode)
    {
      Scan scan = null;
      string selectCommand = @" SELECT artcode, id_gamma, qty FROM scan WHERE artcode = @artcode and id_gamma = @id_gamma";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using (SqlCeCommand command = connect.CreateCommand())
        {
          command.CommandText = selectCommand;
          var param = command.Parameters.Add("artcode", SqlDbType.Int);
          param.Value = artcode;
          param = command.Parameters.Add("id_gamma", SqlDbType.Int);
          param.Value = GlobalArea.CurrentEmployee.GammaID;
          using (SqlCeResultSet res = command.ExecuteResultSet(ResultSetOptions.Scrollable))
          {
            if (!res.HasRows)
              return null;
            if (!res.ReadFirst())
              return null;
            scan = new Scan((int)res.GetInt32(res.GetOrdinal("artcode")),
                            (int)res.GetInt32(res.GetOrdinal("id_gamma")),
                            (int)res.GetInt32(res.GetOrdinal("qty")));
          }
        }
        return scan;
      }
    }

    //создает новую запись OrderItem
    public OrderItem CreateOrderItem(Ean ean)
    {
      OrderItem orderItem = null;
      string insertCommandText = @" INSERT INTO scan(ArtCode, id_gamma, Qty, Dt) VALUES(@artcode, @id_gamma, @qty, GETDATE()) ";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        SqlCeTransaction tx = connect.BeginTransaction();
        SqlCeCommand command = connect.CreateCommand();
        command.CommandText = insertCommandText;
        var param = command.Parameters.Add("artcode", SqlDbType.Int);
        param.Value = ean.ArtCode;
        param = command.Parameters.Add("id_gamma", SqlDbType.Int);
        param.Value = GlobalArea.CurrentEmployee.GammaID;
        param = command.Parameters.Add("qty", SqlDbType.Int);
        param.Value = 0;
        command.Transaction = tx;
        try
        {
          int rowsAffected = command.ExecuteNonQuery();          
          tx.Commit();
          orderItem = GetOrderItemByEan(ean);
        }
        catch (Exception)
        {
          tx.Rollback();
          orderItem = null;
        }
      }
      return orderItem;
    }

    //создает новую запись OrderItem по ШК
    public OrderItem CreateOrderItemByBarcode(string barcode)
    {
      Ean ean = GetEan(barcode);

      return (ean != null) ? CreateOrderItem(ean) : null;
    }
    // обновляет orderItem | возвращает количество затронутіх записей
    public int UpdateScan(Scan scan)
    {      
      string updateCommandText = @" UPDATE scan SET Qty = @qty, dt = GETDATE() WHERE ArtCode = @artcode and id_gamma = @id_gamma ";
      int rowsAffected = 0;
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        SqlCeTransaction tx = connect.BeginTransaction();
        SqlCeCommand command = connect.CreateCommand();
        command.CommandText = updateCommandText;
        var param = command.Parameters.Add("artcode", SqlDbType.Int);
        param.Value = scan.ArtCode;
        param = command.Parameters.Add("id_gamma", SqlDbType.Int);
        param.Value = GlobalArea.CurrentEmployee.GammaID;
        param = command.Parameters.Add("qty", SqlDbType.Int);
        param.Value = scan.Qty;
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
      return rowsAffected;
    }
    // возвращает одну запись справочника
    public Ean GetEan(string barcode)
    {
      Ean ean = null;
      string commandText = @" SELECT top(1) s.artcode, s.ean13, s.names, s.koef,  p.qty, s.nds, s.Manufacturer
    FROM sprean s
    LEFT OUTER JOIN pereuchet p ON s.artcode = p.artcode 
    WHERE s.ean13 = @barcode
    ORDER BY (CASE WHEN p.qty IS NULL THEN 0 ELSE p.qty END) DESC, s.artcode desc  ";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using (SqlCeCommand command = connect.CreateCommand())
        {
          command.CommandText = commandText;
          var param = command.Parameters.Add("barcode", SqlDbType.NVarChar);
          param.Value = barcode;
          using (SqlCeResultSet res = command.ExecuteResultSet(ResultSetOptions.Scrollable))
          {
            try
            {
              if (res.HasRows)
              {
                res.ReadFirst();
                {
                  ean = new Ean();
                  ean.ArtCode = res.GetInt32(0);
                  ean.Ean13 = res.GetString(1);
                  ean.Name = res.GetString(2);
                  ean.Koef = res.GetInt32(3);
                  ean.ControlQty = res.IsDBNull(4) ? 0 : res.GetInt32(4);
                  ean.Nds = res.GetInt32(5);
                  ean.Manufacturer = res.GetString(6);                      
                }
              }
            }
            finally
            {
              res.Close();
            }
          }
        }
      }
      return ean;
    }
    // возвращает количество записей в справочнике
    public int SprEanCount()
    {
      DataSet set = new DataSet();
      string commandString = "select top(1) 1 cnt from SPREAN ";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(commandString, connect))
        {
          adapter.Fill(set);
        }
      }
      int res = set.Tables[0].Rows.Count;
      return res;
    }
    
    // возваращает количество записей в таблице Scan 
    //и кол-во отсканированных препаратов
    public ScanInfo GetScanInfo(int IdGamma)
  {
      ScanInfo scanInfo = null;
      string countCommand = @" SELECT COUNT(*) FROM scan WHERE qty > 0 AND id_gamma = " + GlobalArea.CurrentEmployee.GammaID.ToString();
      string SumQtyCommand = @" SELECT SUM(Qty) FROM scan WHERE id_gamma = " + GlobalArea.CurrentEmployee.GammaID.ToString();
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        using (SqlCeCommand command = connect.CreateCommand())
        {          
          connect.Open();
          command.CommandText = countCommand;
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
    // возвращает объект Информация об базе данных переучета которая была записана при формированиия БД
    public DbInfo GetDbInfo()
    {
      DbInfo dbInfo = new DbInfo();
      List<Ean> eans = new List<Ean>();
      string commandText = @" SELECT pName, val FROM Info ";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using (SqlCeCommand command = connect.CreateCommand())
        {
          command.CommandText = commandText;
          using (SqlCeResultSet res = command.ExecuteResultSet(ResultSetOptions.Scrollable))
          {
            if (res.HasRows)
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
      }
      return dbInfo;
    }

    public IEnumerable<Scan> GetAllScans()
    {
      Scan scan = null;
      string selectCommand = @" SELECT * FROM scan ";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using(SqlCeCommand command = new SqlCeCommand(selectCommand, connect))
        {
          using (SqlCeDataReader reader = command.ExecuteReader())
          {
            if (reader != null)
            {
              while (reader.Read())
              {
                yield return new Scan((int)reader.GetInt32(reader.GetOrdinal("artcode")),
                                      (int)reader.GetInt32(reader.GetOrdinal("id_gamma")),
                                      (int)reader.GetInt32(reader.GetOrdinal("qty"))) 
                                      { Dt = reader.GetDateTime(reader.GetOrdinal("dt"))};
              }
            }
          }
        }
      }
    }
    public int ScanExport(string FileName)
    {
      int count = 0;
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
            foreach (var item in GetAllScans())
            {
                sw.WriteLine(string.Format("{1}{0}{2}{0}{3}{0}{4}", 
                                            '|',
                                            item.GammaID,
                                            item.ArtCode,
                                            item.Qty,
                                            item.Dt.ToUniversalTime().ToString()));
            }
            
          }
        }        
      }
      catch (Exception e) { MessageBox.Show(e.Message, "Ошибка єкспорта в файл fileName", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }
      return 0;    
    }

    public IEnumerable<Employee> GetEmployees()
    {
      string selectCommand = @" SELECT id_gamma, ename, case when barcode is not null then barcode else '' END barcode FROM Employee order by ename";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using (SqlCeCommand command = new SqlCeCommand(selectCommand, connect))
        {
          using (SqlCeDataReader reader = command.ExecuteReader())
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
                    Barcode =  (reader.IsDBNull(reader.GetOrdinal("barcode")))?"" : reader.GetString(reader.GetOrdinal("barcode")),
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
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using (SqlCeCommand command = new SqlCeCommand(selectCommand, connect))
        {
          var param = command.Parameters.Add("barcode", SqlDbType.NVarChar);
          param.Value = barcode;
          using (SqlCeResultSet res = command.ExecuteResultSet(ResultSetOptions.Scrollable))
          {
            if (res.ReadFirst())
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
  }
}
