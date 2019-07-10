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
    private OrderItem _oItem = null;
    public OrderItem OItem { 
      get { return _oItem; }
      set
      {
        _oItem = value;
        if (_oItem != null)
        {
          lbArtCode.Text = _oItem.Ean.ArtCode.ToString();
          lbNds.Text = _oItem.Ean.Nds.ToString();
          lbBarcode.Text = _oItem.Ean.Ean13;
          edtName.Text = _oItem.Ean.Name;
          lbManufacturer.Text = _oItem.Ean.Manufacturer;
          tbQty.Text = _oItem.Qty.ToString();
          tbQty.SelectAll();
          tbQty.Focus();
          RefreshFont();
        }
      } 
    }
    public EditOrderItem(OrderItem oItem)
    {
      InitializeComponent();      
      this.OItem = oItem;      
    }

    private void edtQty_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (OItem == null)
        return;

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
      if (OItem == null)
        return;
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
    private void RefreshFont()
    {
      edtName.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      label1.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbManufacturer.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      lbNds.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      label2.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      label3.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      tbQty.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
    }
  }
}