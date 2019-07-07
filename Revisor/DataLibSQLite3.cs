using System;
using System.Data.SQLite;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
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
    }

    private string CurrentDateSQLStr 
    {
        get 
        { 
          DateTime dt = DateTime.Now;
          return string.Format("{0}-{1}-{2} {3}:{4}:{5}",
                        dt.Year.ToString(),
                        dt.Month.ToString("00"),
                        dt.Day.ToString("00"),
                        dt.Hour.ToString("00"),
                        dt.Minute.ToString("00"),
                        dt.Second.ToString("00"));
        }
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
            cmd.Parameters.Add("StartDt", DbType.String).Value = CurrentDateSQLStr;
            cmd.Parameters.Add("EndDt", DbType.String).Value = CurrentDateSQLStr;
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
      throw new NotImplementedException();
    }

    public int ScanExport(string FileName)
    {
      throw new NotImplementedException();
    }

    public Ean GetEan(string barcode)
    {
      throw new NotImplementedException();
    }

    public int SprEanCount()
    {
      throw new NotImplementedException();
    }

    public DbInfo GetDbInfo()
    {
      throw new NotImplementedException();
    }

    public OrderItem GetOrderItemByEan(Ean ean)
    {
      throw new NotImplementedException();
    }

    public OrderItem CreateOrderItemByBarcode(string barcode)
    {
      throw new NotImplementedException();
    }

    public OrderItem GetOrdeItemByBarcode(string barcode)
    {
      throw new NotImplementedException();
    }

    public ScanInfo GetScanInfo(int IdGamma)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Employee> GetEmployees()
    {
      throw new NotImplementedException();
    }

    public Employee GetEmployee(string barcode)
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
