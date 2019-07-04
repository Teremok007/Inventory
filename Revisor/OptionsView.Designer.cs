namespace BarcodeFramework
{
  partial class OptionsView
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
      this.chkFastScan = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.chkAddMore = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pnMultipleQtyType = new System.Windows.Forms.Panel();
      this.rbPackage = new System.Windows.Forms.RadioButton();
      this.rbPiece = new System.Windows.Forms.RadioButton();
      this.label2 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.pnMultipleQtyType.SuspendLayout();
      this.SuspendLayout();
      // 
      // chkFastScan
      // 
      this.chkFastScan.Location = new System.Drawing.Point(14, 54);
      this.chkFastScan.Name = "chkFastScan";
      this.chkFastScan.Size = new System.Drawing.Size(218, 19);
      this.chkFastScan.TabIndex = 0;
      this.chkFastScan.Text = "Автодобавление. ";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button2);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 143);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(238, 34);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Dock = System.Windows.Forms.DockStyle.Right;
      this.button2.Location = new System.Drawing.Point(133, 0);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(105, 34);
      this.button2.TabIndex = 5;
      this.button2.Text = "Отмена (Esc)";
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Dock = System.Windows.Forms.DockStyle.Left;
      this.button1.Location = new System.Drawing.Point(0, 0);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(136, 34);
      this.button1.TabIndex = 4;
      this.button1.Text = "Подтвердить (Enter)";
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // chkAddMore
      // 
      this.chkAddMore.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.chkAddMore.Location = new System.Drawing.Point(14, 3);
      this.chkAddMore.Name = "chkAddMore";
      this.chkAddMore.Size = new System.Drawing.Size(218, 38);
      this.chkAddMore.TabIndex = 1;
      this.chkAddMore.Text = "Выводить сообщение если";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(14, 32);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(205, 19);
      this.label1.Text = "количество больше расчетного";
      // 
      // pnMultipleQtyType
      // 
      this.pnMultipleQtyType.Controls.Add(this.rbPackage);
      this.pnMultipleQtyType.Controls.Add(this.rbPiece);
      this.pnMultipleQtyType.Location = new System.Drawing.Point(14, 92);
      this.pnMultipleQtyType.Name = "pnMultipleQtyType";
      this.pnMultipleQtyType.Size = new System.Drawing.Size(218, 47);
      // 
      // rbPackage
      // 
      this.rbPackage.Checked = true;
      this.rbPackage.Location = new System.Drawing.Point(9, 28);
      this.rbPackage.Name = "rbPackage";
      this.rbPackage.Size = new System.Drawing.Size(113, 16);
      this.rbPackage.TabIndex = 1;
      this.rbPackage.Text = "Поупаковочно";
      // 
      // rbPiece
      // 
      this.rbPiece.Location = new System.Drawing.Point(9, 7);
      this.rbPiece.Name = "rbPiece";
      this.rbPiece.Size = new System.Drawing.Size(97, 16);
      this.rbPiece.TabIndex = 0;
      this.rbPiece.TabStop = false;
      this.rbPiece.Text = "Поштучно";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
      this.label2.Location = new System.Drawing.Point(36, 70);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(183, 19);
      this.label2.Text = "(Сквозное сканирование)";
      // 
      // OptionsView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(238, 177);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pnMultipleQtyType);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.chkAddMore);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.chkFastScan);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OptionsView";
      this.Text = "OptionsView";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsView_KeyDown);
      this.panel1.ResumeLayout(false);
      this.pnMultipleQtyType.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox chkFastScan;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox chkAddMore;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnMultipleQtyType;
    private System.Windows.Forms.RadioButton rbPackage;
    private System.Windows.Forms.RadioButton rbPiece;
    private System.Windows.Forms.Label label2;
  }
}