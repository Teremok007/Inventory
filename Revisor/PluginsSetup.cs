using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace BarcodeFramework
{
  public partial class PluginsSetup : Form
  {

    public PluginsSetup()
    {
      InitializeComponent();
      RefreshPluginsList();
      lvPlugins.ItemCheck += PluginChecked;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      GlobalArea.PluginManager.SaveAllPlugins();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void RefreshPluginsList()
    {
      PluginCollection pluginCollection;      
      ListViewItem listItem;

      lvPlugins.Items.Clear();
      pluginCollection = GlobalArea.PluginManager.GetPluginList();
      foreach (IDataLibPlugin pluginObj in pluginCollection.Values)
      {
        listItem = new ListViewItem(pluginObj.PluginFullName);
        listItem.Checked = pluginObj.Active;
        lvPlugins.Items.Add(listItem);
      }
    }

    private void btnNewPlugin_Click(object sender, EventArgs e)
    {
      using (ConfigurePlugin configPlugin = new ConfigurePlugin())
      {
        if (configPlugin.ShowDialog() == DialogResult.OK)
        {
          GlobalArea.PluginManager.AddPlugin(configPlugin.PluginLibPath, configPlugin.PluginDatasource, true);
          RefreshPluginsList();
        }
      }
    }

    private void btnRemovePlugin_Click(object sender, EventArgs e)
    {
      string pluginName;
      if (lvPlugins.SelectedIndices.Count == 0)
      {
        MessageBox.Show("Пожалуйста, выделите плагин для изъятия", "Изъятие плагина", 
          MessageBoxButtons.OK, 
          MessageBoxIcon.Exclamation, 
          MessageBoxDefaultButton.Button2);
        return;
      }
      pluginName = lvPlugins.Items[lvPlugins.SelectedIndices[0]].Text;
      GlobalArea.PluginManager.RemovePlugin(pluginName);
      RefreshPluginsList();
    }

    private void lvPlugins_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void PluginChecked(object sender, ItemCheckEventArgs e)
    {
      string selectredPluginName;
      IDataLibPlugin selectedPluginObj;
      selectredPluginName = lvPlugins.Items[e.Index].Text;
      selectedPluginObj = GlobalArea.PluginManager.GetPluginObject(selectredPluginName);
      selectedPluginObj.Active = (e.NewValue == CheckState.Checked);
    }
  }
}