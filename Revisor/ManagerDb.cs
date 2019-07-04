using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace BarcodeFramework
{
  public class ManagerDb
  {
    private SqlCeConnection connect;
    private static string fileExtention = ".sdf";
    private string dbName;
    public string DbName { get { return (DbName ?? "scandb");}  set{ dbName = value; } }
    public string DbFileName { get {return DbName + fileExtention; } }
    public string DBPath { get { return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); } }
    public string DbFullName { get { return DBPath + "\\" + DbFileName; } }
    public string CreationString { get{ return "Data Source='" + DbFullName + "';" + "LCID=1033;Password='admin123';Encrypt=FALSE;"; } }
    public string ConnectionString { get { return "Data Source='" + DbFullName + "'; Password=admin123;"; } }

    public SqlCeConnection GetConnect()
    {
      if (this.connect == null)
        this.connect =  new SqlCeConnection(ConnectionString);
      return this.connect;
    }

    public bool DeleteDb(out string ErrorText)
    {
      ErrorText = "";
      if (!File.Exists(DbFullName))
      {
        return true;
      }
      try
      {
        File.Delete(DbFullName);
      }
      catch (Exception ex)
      {
        ErrorText = "Невозможно удалить БД " 
          + DbName
          + ".\n"
          + ex.Message;
        return false;
      }
      return true;
    }

    public bool CreateDB(string name, out string ErrorText)
    {
      ErrorText = "";
      if (string.IsNullOrEmpty(name))
      {
        ErrorText = "Имя БД не может быть пустым.";
        return false;
      }

      if (!DeleteDb(out ErrorText))
      {
        return false;
      }
       
      using (SqlCeEngine engine = new SqlCeEngine(CreationString))
      {
        try
        {
          engine.CreateDatabase();          
        }
        catch (Exception ex)
        {
          ErrorText = "Ошибка создания БД " + dbName + ".\n" + ex.Message;
          return false;
        }
      }
      if (!VerifyDBConnect(out ErrorText))
      {
        return false;
      }
      if (!CreateSprEanTable(out ErrorText))
      {
        return false;
      }
      if (!CreateOrderTable(out ErrorText))
      {
        return false;
      }
      return true;    
    }
    
    public bool VerifyDBConnect(out string ErrorText)
    {
      ErrorText = "";
      using (SqlCeConnection connection = GetConnect())
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

    private void DropTable(string tableName)
    {
      string commandString = string.Format("DROP TABLE {0}", tableName);
      using (var connect = this.GetConnect())
      {
        connect.Open();
        using (SqlCeCommand command = connect.CreateCommand())
        {
          try
          {
            command.ExecuteNonQuery();
          }
          catch
          {}
        }
      }
    }

    public bool CreateSprEanTable(out string ErrorText)
    {
      ErrorText = "";
      DropTable("SPREAN");
      using (SqlCeConnection connection = GetConnect())
      {
        try
        {
          connection.Open();
          SqlCeCommand command = connection.CreateCommand();
          command.CommandText = @"CREATE TABLE SPREAN
(
  artcode int,
  ean13 nvarchar(13),
  names nvarchar(200),
  primary key (ean13, artcode)
)";
          command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          ErrorText = "Ошибка создания таблицы SPREAN" + "\n" + ex.Message;
          return false;
        }
      }
      return true;
    }

    public bool CreateOrderTable(out string ErrorText)
    {
      ErrorText = "";
      DropTable("OHead");
      DropTable("OSpec");
      using (SqlCeConnection connection = GetConnect())
      {
        try
        {
          connection.Open();
          SqlCeCommand command = connection.CreateCommand();
          command.CommandText = @"CREATE TABLE OHead
(
  OHeadGUID UNIQUEIDENTIFIER UNIQUE,
  Num nvarchar(14),
  DateCreated DATETIME,
  Status int,
  PRIMARY KEY(OHeadGUID)
)";
          command.ExecuteNonQuery();

          command.CommandText = @"CREATE TABLE OSpec
(
  OSpecGUID UNIQUEIDENTIFIER UNIQUE,
  OHeadGUID UNIQUEIDENTIFIER,
  DateCreated DATETIME,
  ArtCode int,
  Ean13 NVARCHAR(20),
  Name  NVARCHAR(200),
  PRIMARY KEY(OSpecGUID)
)";
          command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
          ErrorText = "Ошибка создания таблицы SPREAN" + "\n" + ex.Message;
          return false;
        }
      }
      return true;
    }
  }
}
