using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;

namespace BarcodeFramework
{
  public class PluginManager
  {
    private IDataLibPlugin activePlugin;
    private PluginCollection plugins;
    public PluginCollection GetPluginList()
    {
      return plugins;
    }
    public IDataLibPlugin GetPluginObject(string PluginName)
    {
      return plugins.Item(PluginName);
    }

    public IDataLibPlugin AddPlugin(string PluginPath, string PluginDatasource, bool Active)
    {
      Assembly assemblyObj;
      IDataLibPlugin pluginObj;

      assemblyObj = Assembly.LoadFrom(PluginPath);
      pluginObj = (IDataLibPlugin)(assemblyObj.CreateInstance("BarcodeFramework.DataLibPlugin"));
      pluginObj.Datasource = PluginDatasource;
      plugins.Add(pluginObj);
      return pluginObj;
    }

    public void RemovePlugin(string PluginName)
    {
      plugins.Remove(PluginName);
    }

    
    public PluginManager() : base()
    {}

    public IDataLibPlugin GetActivePlugin()
    {
      if (activePlugin == null)
      {
        activePlugin = new DataLibPluginCeDB();
        activePlugin.Datasource = "scandb";
      }
      return activePlugin;
    }
  }
}
