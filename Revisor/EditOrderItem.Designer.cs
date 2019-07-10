namespace BarcodeFramework
{
  partial class EditOrderItem
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.edtName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.lbBarcode = new System.Windows.Forms.Label();
      this.lbArtCode = new System.Windows.Forms.Label();
      this.lbNds = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lbManufacturer = new System.Windows.Forms.Label();
      this.tbQty = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Controls.Add(this.btnOK);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 237);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(241, 28);
      // 
      // btnCancel
      // 
      this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnCancel.Location = new System.Drawing.Point(137, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(104, 28);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Отмена (Esc)";
      // 
      // btnOK
      // 
      this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnOK.Location = new System.Drawing.Point(0, 0);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(137, 28);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Подтвердить (Enter)";
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // edtName
      // 
      this.edtName.BackColor = System.Drawing.SystemColors.ScrollBar;
      this.edtName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
      this.edtName.Location = new System.Drawing.Point(3, 2);
      this.edtName.Multiline = true;
      this.edtName.Name = "edtName";
      this.edtName.Size = new System.Drawing.Size(235, 131);
      this.edtName.TabIndex = 5;
      this.edtName.TabStop = false;
      this.edtName.Text = "Съешь еще этих спелых и вкусных яблок";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label3.Location = new System.Drawing.Point(3, 193);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(107, 17);
      this.label3.Text = "Ко-во (всего):";
      // 
      // lbBarcode
      // 
      this.lbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbBarcode.Location = new System.Drawing.Point(0, 219);
      this.lbBarcode.Name = "lbBarcode";
      this.lbBarcode.Size = new System.Drawing.Size(93, 15);
      this.lbBarcode.Text = "lbBarcode";
      this.lbBarcode.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lbArtCode
      // 
      this.lbArtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lbArtCode.ForeColor = System.Drawing.Color.Maroon;
      this.lbArtCode.Location = new System.Drawing.Point(137, 220);
      this.lbArtCode.Name = "lbArtCode";
      this.lbArtCode.Size = new System.Drawing.Size(93, 15);
      this.lbArtCode.Text = "lbArtCode";
      this.lbArtCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lbNds
      // 
      this.lbNds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbNds.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
      this.lbNds.Location = new System.Drawing.Point(45, 169);
      this.lbNds.Name = "lbNds";
      this.lbNds.Size = new System.Drawing.Size(61, 24);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(3, 169);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 15);
      this.label2.Text = "НДС:";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label1.Location = new System.Drawing.Point(3, 136);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(121, 14);
      this.label1.Text = "Производитель:";
      // 
      // lbManufacturer
      // 
      this.lbManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lbManufacturer.Location = new System.Drawing.Point(3, 150);
      this.lbManufacturer.Name = "lbManufacturer";
      this.lbManufacturer.Size = new System.Drawing.Size(235, 19);
      // 
      // tbQty
      // 
      this.tbQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.tbQty.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
      this.tbQty.Location = new System.Drawing.Point(112, 184);
      this.tbQty.Name = "tbQty";
      this.tbQty.Size = new System.Drawing.Size(113, 35);
      this.tbQty.TabIndex = 9;
      this.tbQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQty_KeyPress);
      // 
      // EditOrderItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(241, 265);
      this.Controls.Add(this.tbQty);
      this.Controls.Add(this.lbManufacturer);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lbNds);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lbBarcode);
      this.Controls.Add(this.lbArtCode);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.edtName);
      this.Controls.Add(this.panel1);
      this.Name = "EditOrderItem";
      this.Text = "Редактирование";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.TextBox edtName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lbBarcode;
    private System.Windows.Forms.Label lbArtCode;
    private System.Windows.Forms.Label lbNds;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lbManufacturer;
    private System.Windows.Forms.TextBox tbQty;
  }
}