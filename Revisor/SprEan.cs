using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Reflection;

namespace BarcodeFramework
{
    public class SprEan
    {
        private SortedList<string, Ean> list;
        public int Count
                {
                    get
                    { 
                        if (this.list == null)
                            return 0;
                        return this.list.Count;
                    }
                }

        public DataSet FindEanByBarcode(string barcode)
        {          
          DataSet dataSet = new DataSet();
          string commandString = "SELECT artcode, ean13, names FROM SPREAN WHERE ean13 = @Barcode";
          using (SqlCeConnection connection = new ManagerDb().GetConnect())
          {
            connection.Open();
            using(SqlCeCommand command = connection.CreateCommand())
            {                                
              using (SqlCeDataAdapter adapter = new SqlCeDataAdapter())
              {
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.CommandText = commandString;                
                adapter.SelectCommand.Parameters.AddWithValue("@Barcode", barcode);
                adapter.TableMappings.Add("Table", "FoundedEan");
                adapter.Fill(dataSet);
              }
            }
          }
          return dataSet;
        }

        public SprEan LoadEanFromFile(string fileName)
        {          
          string command = @"SELECT artcode, ean13, names FROM SPREAN WHERE 1 = 0";
          ManagerDb managerDb = new ManagerDb();
          using (SqlCeConnection conn = managerDb.GetConnect())
          {
            string ErrorText; 
            if (!managerDb.CreateSprEanTable(out ErrorText))
            {
              return null;
            }
            conn.Open();
            using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command, conn))
            {              
              using (DataSet dataSet = new DataSet())
              {
                adapter.Fill(dataSet, "SPREAN");
                string line;
                using (StreamReader sr = new StreamReader(fileName))
                {
                  while ((line = sr.ReadLine()) != null)
                  {
                    try
                    {
                      var datas = line.Split('|');
                      var newRow = dataSet.Tables["SPREAN"].NewRow();
                      newRow["ArtCode"] = int.Parse(datas[0]);
                      newRow["Ean13"] = datas[1];
                      newRow["Names"] = datas[2];
                      dataSet.Tables["SPREAN"].Rows.Add(newRow);
                    }
                    catch
                    {
                      continue;
                    }
                  }
                }
                new SqlCeCommandBuilder(adapter);
                adapter.Update(dataSet, "SPREAN");
              }
            }
          }
          return this;
        }        
    }
}
