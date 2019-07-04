using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public partial class EditOrderItem : Form
  {
    public OrderItem OItem { get; set; }
    public EditOrderItem(OrderItem oItem)
    {
      InitializeComponent();      
      this.OItem = oItem;
      lbArtCode.Text = oItem.Ean.ArtCode.ToString();
      lbNds.Text = oItem.Ean.Nds.ToString();
      lbBarcode.Text = oItem.Ean.Ean13;
      edtName.Text = oItem.Ean.Name;
      lbManufacturer.Text = OItem.Ean.Manufacturer;
      tbQty.Text = oItem.Qty.ToString();
      tbQty.SelectAll();
      tbQty.Focus();
    }

    private void edtQty_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == Convert.ToChar(Keys.Return))
      {
        OItem.Qty = int.Parse(tbQty.Text);
        this.DialogResult = DialogResult.OK;
        this.Close();
        return;
      }
      if (e.KeyChar == Convert.ToChar(Keys.Escape))
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
        return;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      OItem.Qty = 0;
      if (tbQty.Text.Length > 0) 
       OItem.Qty = int.Parse(tbQty.Text);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = false;
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
      {
        e.Handled = true;
      }
      if (e.KeyChar == Convert.ToChar(Keys.Return))
      {
        btnOK_Click(btnOK, EventArgs.Empty);
        return;
      }
      if (e.KeyChar == Convert.ToChar(Keys.Escape))
      {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
        return;
      }
    }
  }
}