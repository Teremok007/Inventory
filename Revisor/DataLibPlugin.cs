using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public class DataLibPlugin : DataLibGeneral, IDataLibPlugin
  {
    public override bool CreateScanDatabase(string name)
    {
      if (!base.CreateScanDatabase(name))
        return false;

      string ErrorText;
      if (!CreateOrderTable(out ErrorText))
      {
        return false;
      }
      return true;
    }

    public string PluginPath
    {
      get { return pluginPath; }
      set { pluginPath = value; }
    }


    private bool CreateOrderTable(out string ErrorText)
    {
      ErrorText = "";
      DropTable("OHead");
      DropTable("OSpec");
      using (SqlCeConnection connection = new SqlCeConnection(Datasource))
      {
        try
        {
          connection.Open();
          SqlCeCommand command = connection.CreateCommand();
          command.CommandText = resourceManger.GetString("OHead_SQL");//@"CREATE TABLE OHead(OHeadGUID UNIQUEIDENTIFIER UNIQUE,Num nvarchar(14),DateCreated DATETIME,Status int,PRIMARY KEY(OHeadGUID))";
          command.ExecuteNonQuery();

          command.CommandText = resourceManger.GetString("OSpec_SQL"); //@"CREATE TABLE OSpec(  OSpecGUID UNIQUEIDENTIFIER UNIQUE,  OHeadGUID UNIQUEIDENTIFIER,  DateCreated DATETIME,  ArtCode int,  Ean13 NVARCHAR(20),  Name  NVARCHAR(200),  PRIMARY KEY(OSpecGUID))";
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

    /*=================================*/

    public DataSet GetOrderDetails(Guid orderGUID)
    {
      DataSet resSet = new DataSet();
      string commandString = "SELECT * FROM OSpec WHERE OHeadGEUID = @HeadGUID";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        using (SqlCeDataAdapter adapter = new SqlCeDataAdapter())
        {
          adapter.SelectCommand.CommandType = CommandType.Text;
          adapter.SelectCommand.CommandText = commandString;
          adapter.SelectCommand.Parameters.AddWithValue("@HeadGUID", orderGUID);
          adapter.TableMappings.Add("Table", "OSpecDetails");
          adapter.Fill(resSet);
        }
      }
      return resSet;    
    }

    public DataSet GetOrderList()
    {
      DataSet resSet = new DataSet();
      string commandString = "SELECT * FROM OSpec";
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        using (SqlCeDataAdapter adapter = new SqlCeDataAdapter())
        {
          adapter.SelectCommand.CommandType = CommandType.Text;
          adapter.SelectCommand.CommandText = commandString;          
          adapter.TableMappings.Add("Table", "OSpec");
          adapter.Fill(resSet);
        }
      }
      return resSet;    
    }

    public void ClearSpec(DataSet ds)
    {
      using (SqlCeConnection connect = new SqlCeConnection(Datasource))
      {
        connect.Open();
        using(SqlCeDataAdapter adapter = new SqlCeDataAdapter())
        {
          

        }
      }
    }

  }

}
