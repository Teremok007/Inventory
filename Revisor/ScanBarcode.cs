using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public class ScanBarcode
  {
    public static bool DBIsReady = false;
    public static void Main()
    {
      
      InitializeApp();
      //MainMenu mainMenu = new MainMenu();
      //Application.Run(mainMenu);
      //mainMenu.Dispose();
      //mainMenu = null;
      if (!DBIsReady)
      {
        //MessageBox.Show("База данных не готова к работе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        return;
      }
      try
      {
          if (!Authorized())
            return;
          OrderViewer orderView = new OrderViewer();
          Application.Run(orderView);
          orderView.Dispose();
          orderView = null;
      }
      catch (Exception e)
      {
        GlobalArea.Logger.Error("[Error][Ошибка чтения таблицы Сотрудников] " + e.ToString());
        throw;
      }
    }
    
    public static bool Authorized()
    {
      bool ready = false;
      using(AuthorisationForm auth = new AuthorisationForm())
      {
        if (auth.ShowDialog() == DialogResult.OK)
        {
          ready = true;
        }
      }
      return ready;
    }

    public static void InitializeApp()
    {      
      try
      {
        var plug = GlobalArea.PluginManager.GetActivePlugin();        
        if (plug == null)
        {
          MessageBox.Show("Не указан модуль работы с БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);          
        }
        GlobalArea.Logger.Info("Try to connect DB. " + plug.PluginFullName + " Datasource " + plug.Datasource);
        if (!plug.ConnectDatabase())
        {
          GlobalArea.Logger.Info("[Connect to DB is failed.] "  + plug.PluginFullName + " Datasource " + plug.Datasource);
          MessageBox.Show("Ошибка проверки подключения к БД.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        
        DBIsReady = true;   
        //GlobalArea.PluginManager.GetActivePlugin().ConnectDatabase();
      }
      catch(Exception ex)
      {
        GlobalArea.Logger.Error("[Exception][Ошибка проверки подключения к БД.] " + ex.ToString());
        DBIsReady = false;
        throw;
      }
    }
    public static void DeInitializeApp()
    {
    }
  }
}
