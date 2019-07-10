using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarcodeFramework
{
  public partial class EditQty : Form
  {
    public string Ean13 { get; set; }
    public int ArtCode { get; set; }
    public string ArtName { get; set; }
    public int Qty
    {
      get { return int.Parse(tbQty.Text); }
      set { tbQty.Text = value.ToString(); }
    }
    public OrderItem selectedItem;
    
    public EditQty()
    {
      InitializeComponent();
      this.cbArt.SelectedIndexChanged += this.cbArt_SelectedIndexChanged;
    }

    void cbArt_SelectedIndexChanged(object sender, EventArgs e)
    {
      selectedItem = (OrderItem)this.cbArt.SelectedItem;
      lblName.Text = String.Format("{0}\n{1}",selectedItem.Ean.Name,selectedItem.Ean.Manufacturer);
      tbQty.Text = ((GlobalArea.AppOption.MultypleQtyType == MultipleQty.BY_PACKAGE) ? selectedItem.Ean.Koef : 1).ToString();
      lbScanedQty.Text  = selectedItem.Qty.ToString();
      lbBarcode.Text    = selectedItem.Ean.Ean13;
      lblKoef.Text = selectedItem.Ean.Koef.ToString();
      lbArtCode.Text    = selectedItem.ArtCode.ToString();
      lbNds.Text        = selectedItem.Ean.Nds.ToString() + "%";
      lblQtyInApt.Text = selectedItem.Ean.ControlQty.ToString();
      tbQty.Focus();
      tbQty.SelectAll();

    }

    private void EditQty_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == Convert.ToChar(Keys.Return))
      {
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

    private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = false; ;
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
      {
        e.Handled = true;
      }
      if (e.KeyChar == Convert.ToChar(Keys.Return))
      {
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

    private void button1_Click(object sender, EventArgs e)
    {

    }
    public void RefreshFont()
    {
      lblName.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      tbQty.Font = new System.Drawing.Font("Arial", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      label2.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbNds.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      label3.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbScanedQty.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      label5.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      lblKoef.Font = new System.Drawing.Font("Tahoma", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      label1.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      lblQtyInApt.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      lbBarcode.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      lbArtCode.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
    }

  }
}