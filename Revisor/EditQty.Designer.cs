namespace BarcodeFramework
{
  partial class EditQty
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
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.EditQtyPanel = new System.Windows.Forms.Panel();
      this.lblCnt = new System.Windows.Forms.Label();
      this.cbArt = new System.Windows.Forms.ComboBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblQtyInApt = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblKoef = new System.Windows.Forms.Label();
      this.tbQty = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.lbNds = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lbScanedQty = new System.Windows.Forms.Label();
      this.lbBarcode = new System.Windows.Forms.Label();
      this.lbArtCode = new System.Windows.Forms.Label();
      this.lblName = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.EditQtyPanel.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button2);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 249);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(238, 26);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Dock = System.Windows.Forms.DockStyle.Right;
      this.button2.Location = new System.Drawing.Point(135, 0);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(103, 26);
      this.button2.TabIndex = 3;
      this.button2.Text = "Отмена (Esc)";
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Dock = System.Windows.Forms.DockStyle.Left;
      this.button1.Location = new System.Drawing.Point(0, 0);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(136, 26);
      this.button1.TabIndex = 2;
      this.button1.Text = "Подтвердить (Enter)";
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // EditQtyPanel
      // 
      this.EditQtyPanel.Controls.Add(this.lblCnt);
      this.EditQtyPanel.Controls.Add(this.cbArt);
      this.EditQtyPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.EditQtyPanel.Location = new System.Drawing.Point(0, 0);
      this.EditQtyPanel.Name = "EditQtyPanel";
      this.EditQtyPanel.Size = new System.Drawing.Size(238, 10);
      this.EditQtyPanel.Visible = false;
      // 
      // lblCnt
      // 
      this.lblCnt.Location = new System.Drawing.Point(2, 3);
      this.lblCnt.Name = "lblCnt";
      this.lblCnt.Size = new System.Drawing.Size(16, 22);
      // 
      // cbArt
      // 
      this.cbArt.BackColor = System.Drawing.SystemColors.HighlightText;
      this.cbArt.Location = new System.Drawing.Point(24, 3);
      this.cbArt.Name = "cbArt";
      this.cbArt.Size = new System.Drawing.Size(211, 23);
      this.cbArt.TabIndex = 0;
      this.cbArt.Visible = false;
      this.cbArt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditQty_KeyPress);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lblQtyInApt);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.lblKoef);
      this.panel2.Controls.Add(this.tbQty);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.lbNds);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.lbScanedQty);
      this.panel2.Controls.Add(this.lbBarcode);
      this.panel2.Controls.Add(this.lbArtCode);
      this.panel2.Controls.Add(this.lblName);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 10);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(238, 239);
      // 
      // lblQtyInApt
      // 
      this.lblQtyInApt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblQtyInApt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
      this.lblQtyInApt.Location = new System.Drawing.Point(191, 190);
      this.lblQtyInApt.Name = "lblQtyInApt";
      this.lblQtyInApt.Size = new System.Drawing.Size(45, 20);
      this.lblQtyInApt.Text = "9999";
      this.lblQtyInApt.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(126, 192);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 17);
      this.label1.Text = "Ост в апт.";
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
      this.label5.Location = new System.Drawing.Point(3, 192);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(54, 20);
      this.label5.Text = "Коеф.";
      // 
      // lblKoef
      // 
      this.lblKoef.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
      this.lblKoef.Location = new System.Drawing.Point(58, 193);
      this.lblKoef.Name = "lblKoef";
      this.lblKoef.Size = new System.Drawing.Size(60, 20);
      this.lblKoef.Text = "8888";
      // 
      // tbQty
      // 
      this.tbQty.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
      this.tbQty.Location = new System.Drawing.Point(2, 152);
      this.tbQty.Name = "tbQty";
      this.tbQty.Size = new System.Drawing.Size(90, 37);
      this.tbQty.TabIndex = 7;
      this.tbQty.Text = "9999";
      this.tbQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQty_KeyPress);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label3.Location = new System.Drawing.Point(157, 152);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 17);
      this.label3.Text = "Скан. кол.";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lbNds
      // 
      this.lbNds.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
      this.lbNds.Location = new System.Drawing.Point(101, 169);
      this.lbNds.Name = "lbNds";
      this.lbNds.Size = new System.Drawing.Size(47, 16);
      this.lbNds.Text = "20%";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(106, 152);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 15);
      this.label2.Text = "ндс";
      // 
      // lbScanedQty
      // 
      this.lbScanedQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lbScanedQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
      this.lbScanedQty.Location = new System.Drawing.Point(157, 169);
      this.lbScanedQty.Name = "lbScanedQty";
      this.lbScanedQty.Size = new System.Drawing.Size(79, 20);
      this.lbScanedQty.Text = "9999";
      this.lbScanedQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lbBarcode
      // 
      this.lbBarcode.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
      this.lbBarcode.Location = new System.Drawing.Point(2, 218);
      this.lbBarcode.Name = "lbBarcode";
      this.lbBarcode.Size = new System.Drawing.Size(118, 18);
      this.lbBarcode.Text = "1234567890123";
      // 
      // lbArtCode
      // 
      this.lbArtCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
      this.lbArtCode.ForeColor = System.Drawing.Color.Maroon;
      this.lbArtCode.Location = new System.Drawing.Point(126, 218);
      this.lbArtCode.Name = "lbArtCode";
      this.lbArtCode.Size = new System.Drawing.Size(107, 18);
      this.lbArtCode.Text = "123456789";
      this.lbArtCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lblName
      // 
      this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
      this.lblName.Location = new System.Drawing.Point(3, 2);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(230, 150);
      this.lblName.Text = "dfsd sdfsd f hgjgh gfjfjfghghj gh ghghj fjjhjtyjtyj ytyj tyjtyjutyty";
      // 
      // EditQty
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(238, 275);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.EditQtyPanel);
      this.Controls.Add(this.panel1);
      this.MinimizeBox = false;
      this.Name = "EditQty";
      this.Text = "Ввод количества";
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditQty_KeyPress);
      this.panel1.ResumeLayout(false);
      this.EditQtyPanel.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel EditQtyPanel;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lblName;
    public System.Windows.Forms.ComboBox cbArt;
    public System.Windows.Forms.Label lblCnt;
    private System.Windows.Forms.Label lbBarcode;
    private System.Windows.Forms.Label lbScanedQty;
    private System.Windows.Forms.Label lbNds;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.TextBox tbQty;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblKoef;
    private System.Windows.Forms.Label lbArtCode;
    private System.Windows.Forms.Label lblQtyInApt;
    private System.Windows.Forms.Label label1;
  }
}