using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public partial class OptionsView : Form
  {
    public OptionsView()
    {
      InitializeComponent();
      chkFastScan.Checked = GlobalArea.AppOption.FastScan;
      chkAddMore.Checked = GlobalArea.AppOption.IsMoreQtyMessage;
      rbPackage.Checked = GlobalArea.AppOption.MultypleQtyType == MultipleQty.BY_PACKAGE;
      rbPiece.Checked = GlobalArea.AppOption.MultypleQtyType == MultipleQty.BY_PIECE;
    }
    private void Save()
    {
      GlobalArea.AppOption.IsMoreQtyMessage = chkAddMore.Checked;
      GlobalArea.AppOption.FastScan = chkFastScan.Checked;
      GlobalArea.AppOption.MultypleQtyType = GetMultipleQtyType();
    }
    private void button1_Click(object sender, EventArgs e)
    {
      Save();
    }
    //GetMultipleType returns MultipleQty 
    private MultipleQty GetMultipleQtyType()
    {
      // считать поштучно
      if (rbPiece.Checked)
        return MultipleQty.BY_PIECE;
      // считать поупаковочно
      if (rbPackage.Checked)
        return MultipleQty.BY_PACKAGE;
      // по-умолчанию считать поупаковочно
      return MultipleQty.BY_PACKAGE; 
    }

    private void OptionsView_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return)
      {
        Save();
        this.Close();
      }
      if (e.KeyCode == Keys.Escape)
      {
        this.Close();
      }
    }

  }
}