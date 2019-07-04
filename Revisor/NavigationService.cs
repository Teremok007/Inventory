using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  class NavigationService
  {
    public static DialogResult ShowDialog(string dialogName, object Arg)
    {
      DialogResult dialogResult = DialogResult.Cancel;
      switch (dialogName)
      {
        //case "SetupPlugin":
        //  using (PluginsSetup pluginSetup = new PluginsSetup())
        //  {
        //    dialogResult = pluginSetup.ShowDialog();
        //    pluginSetup.Close();
        //  }
        //  break;
        case "NewOrder":
          using (OrderViewer orderView = new OrderViewer())
          {            
            orderView.Text = "Сканер";
            dialogResult = orderView.ShowDialog();
            orderView.Close();
          }
          break;
        case "SetupDatasource":
          using (ConfigurePlugin confPlugin = new ConfigurePlugin())
          {
            dialogResult = confPlugin.ShowDialog();
            confPlugin.Close();
          }
          break;
        case "Options":
          using (OptionsView optionsView = new OptionsView())
          {
            optionsView.ShowDialog();
            optionsView.Close();
          }
          break;
      }
      return dialogResult;
    }
    private void ShowMessageIfMore(string message)
    {
      MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
    }
  }
}
