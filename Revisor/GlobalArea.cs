using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  class GlobalArea
  {
    private static PluginManager pluginManager = new PluginManager();
    public static PluginManager PluginManager { get { return pluginManager; } }
    public static AppOption AppOption = new AppOption();
    public static DeviceInfo DeviceInfo = new DeviceInfo();
    public static Employee CurrentEmployee { get; set; }

    private static DbInfo dbInfo;
    public static DbInfo DbInfo 
    { 
        get 
        { 
          if (dbInfo == null) 
            dbInfo = GlobalArea.PluginManager.GetActivePlugin().GetDbInfo();
          return dbInfo;
        }
    }
    public static string CurrentDateSQLStr
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
  }
}
