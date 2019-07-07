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
        MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
        if (!plug.ConnectDatabase())
        {
          MessageBox.Show("Ошибка проверки подключения к БД.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        if (plug.GetDbInfo().Version.CompareTo("2.0.1") != 0)
        {
          MessageBox.Show("Версия БД " + plug.GetDbInfo().Version + " необходима " + "2.0.1","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        else
        {
          DBIsReady = true;
        }
        //GlobalArea.PluginManager.GetActivePlugin().ConnectDatabase();
      }
      catch(Exception ex)
      {
        MessageBox.Show("Ошибка проверки подключения к БД.\n"+ ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }
    public static void DeInitializeApp()
    {
    }
  }
}
