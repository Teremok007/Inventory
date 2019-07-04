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
  }
}
