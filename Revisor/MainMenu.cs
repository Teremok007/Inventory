using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public partial class MainMenu : Form
  {
    public MainMenu()
    {
      InitializeComponent();
      this.Text = string.Format("Переучет... ({0}) {1}", GlobalArea.DbInfo.AptekaID, GlobalArea.DbInfo.AptekaName);
      statusBar.Text = string.Format("Дт: {0} | Вер.: {1} |Ean:{2}|Per:{3}|", 
                                      GlobalArea.DbInfo.PereuchetDateText, 
                                      GlobalArea.DbInfo.Version,
                                      GlobalArea.DbInfo.SprEanRowCountText,
                                      GlobalArea.DbInfo.PereuchetRowCountText);
      lstMainMenu.ItemActivate += lstMainMenu_ItemActivate;
      lstMainMenu.Focus();
      lstMainMenu.Items[0].Selected = true;      
    }
    
    public void lstMainMenu_ItemActivate(object sendrt, System.EventArgs e)
    {
      if (lstMainMenu.SelectedIndices.Count > 0)
      {
        string tag = System.Convert.ToString(lstMainMenu.Items[lstMainMenu.SelectedIndices[0]].Tag);
        NavigationService.ShowDialog(tag, null);
      }
    }

    private void lstMainMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Logout_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}