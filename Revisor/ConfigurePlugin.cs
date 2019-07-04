using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace BarcodeFramework
{
  public partial class ConfigurePlugin : Form
  {
    private string pluginDatasource;
    private string pluginLibPath;
    private IDataLibPlugin pluginObj;

    public string PluginDatasource
    {
      get { return pluginDatasource; }
      set { pluginDatasource = value; }
    }
    public string PluginLibPath
    {
      get { return pluginLibPath; }
      set { pluginLibPath = value; }
    }

    public ConfigurePlugin()
    {
      //InitializeComponent();
      //txtDatasource.Text = "scandb";
      //if (File.Exists(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\scandb.sdf"))
      //{
      //  btnCreateDatabase.Enabled = false;
      //}
      //pluginObj = GlobalArea.PluginManager.GetActivePlugin();
      ////if (pluginObj == null)
      ////{
      ////  btnLoadSprEan.Enabled = false;
      ////  btnCreateDatabase.Enabled = false;
      ////}
      //btnOpenSprFile.Focus();
    }

    private void btnCreateDatabase_Click(object sender, EventArgs e)
    {
      //if (pluginObj == null)
      //  return;
      //if (pluginObj.CreateScanDatabase(txtDatasource.Text) == true)
      //{
      //  txtDatasource.Text = pluginObj.Datasource;
      //  MessageBox.Show("База данных создана успешно", "Создание БД");
      //}
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //ofdFileBrowse.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
      //ofdFileBrowse.FileName = "sprean.spr";
      //ofdFileBrowse.Filter = "Файлы БД(*.spr)|*.spr";
      //if (ofdFileBrowse.ShowDialog() == DialogResult.OK)
      //{
      //  txtImportSprEan.Text = ofdFileBrowse.FileName;
      //  btnLoadSprEan.Focus();
      //}
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnLoadSprEan_Click(object sender, EventArgs e)
    {
      //if ((pluginObj == null) || string.IsNullOrEmpty(txtImportSprEan.Text))
      //  return;

      //try
      //{
      //  statusBar.Text = "Загрузка справочника препаратов. Ожидайте...";
      //  statusBar.Refresh();
      //  if (pluginObj.FillSprEanFromFile(txtImportSprEan.Text) == true)
      //  {
      //    txtDatasource.Text = pluginObj.Datasource;
      //    MessageBox.Show("Справочник препаратов загружен", "Загрузка SprEan");
      //    statusBar.Text = "Справочник препаратов загружен";
      //  }
      //}
      //finally
      //{
      //   statusBar.Text = "Готов";
      //}
    }
  }
}