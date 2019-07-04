using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public class DataLibPluginXML : IDataLibPlugin
  {     
    private static string DBPath { get { return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); } }
    private static string OrdersFile = "ScanOrders";
    private static string fileExtention = ".cvs";
    private DataLibGeneral DB = new DataLibGeneral();
    private char Delimiter = '|';
    //private Order order;
    public string PluginFullName { get { return "XML Plugin"; } }
    public string PluginPath { get { return ""; } set { } }
    public string DbName { get { return OrdersFile; } }
    
    public string FileNameSave
    {
      get { return DBPath + "\\" + OrdersFile + "_save" + fileExtention; }
    }    

    public string Datasource
    {
      get { return DB.Datasource; }
      set { }
    }

    public string FileName
    {
      get { return DBPath + "\\" + OrdersFile + fileExtention; } 
      set { } 
    }
    public DataLibPluginXML()
    {
      
    }
    public int SprEanCount()
    { 
      return DB.SprEanCount();
    }

    public Ean GetEan(string barcode)
    {
      return DB.GetEan(barcode);
    }
    public Order GetOrder()
    {
      Order order = new Order();
      try
      {
        using (FileStream fs = new FileStream(FileName, FileMode.Open))
        {
          using (StreamReader sr = new StreamReader(fs))
          {
            string line;
            while (!sr.EndOfStream)
            {
              try
              {
                line = sr.ReadLine();
                string[] data = line.Split(Delimiter);
                if ((data.Length) < 4)
                  continue;
                Ean ean = GetEan(data[2]);
                OrderItem item = new OrderItem(ean, new Scan(int.Parse(data[0]), GlobalArea.CurrentEmployee.GammaID));
                item.Id = new Guid(Convert.ToString(data[4]));
                item.Qty = int.Parse(data[1]);
                order.OSpec.Add(item.Ean.Ean13, item);
              }
              catch (Exception) { }
            }
          }
        }
      }
      catch (FileNotFoundException) { }      
      return order;
    }
    public DbInfo GetDbInfo() 
    {
      return DB.GetDbInfo();
    }
    public int ScanExport(string FileName)
    {
      try
      {
        if (File.Exists(FileNameSave))
          File.Delete(FileNameSave);
        if (File.Exists(FileName))
          File.Copy(FileName, FileNameSave);

        using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
        {
          using (StreamWriter sw = new StreamWriter(fs))
          {
            sw.WriteLine(string.Format(";Ver={0};Date={1}{2}{3};DeviceID={4};Host={5}",
                                       GlobalArea.DbInfo.Version,
                                       GlobalArea.DbInfo.PereuchetDate.Year.ToString(),
                                       GlobalArea.DbInfo.PereuchetDate.Month.ToString("00"),
                                       GlobalArea.DbInfo.PereuchetDate.Day.ToString("00"),
                                       GlobalArea.DeviceInfo.DeviceID,
                                       GlobalArea.DeviceInfo.HostName));
            //foreach (var item in order.OSpec.Values)
            //  sw.WriteLine(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}", 
            //                              Delimiter,  
            //                              item.Ean.ArtCode.ToString(),
            //                              item.Qty,
            //                              item.Ean.Ean13,
            //                              item.Ean.Name,                                         
            //                              item.Id.ToString()));
          }
        }
        
      }
      catch (Exception e) { MessageBox.Show(e.Message, "Ошибка записи...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }
      return 0;
      }

    //методы управления БД
    public bool ConnectDatabase()
    {
      return DB.ConnectDatabase();
    }

    #region IDataLibPlugin Members


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
    public OrderItem Save(ref OrderItem orderItem)
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

