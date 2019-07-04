using System;
using System.Collections;
using System.Text;

namespace BarcodeFramework
{
  public class PluginCollection : Hashtable
  {
    public IDataLibPlugin Add(IDataLibPlugin PluginObject)
    {
      if (base.Contains(PluginObject.PluginFullName) == false)
      {
        base.Add(PluginObject.PluginFullName, PluginObject);
        return PluginObject;
      }      
      return null;
    }
    public IDataLibPlugin Item(string PluginName)
    {
      foreach (IDataLibPlugin item in this.Values)
      {
        if (item.PluginFullName == PluginName)
        {
          return item;
        }
      }
      return null;
    }
  }
}
