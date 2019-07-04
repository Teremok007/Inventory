namespace BarcodeFramework
{
  partial class ConfigurePlugin
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
      this.btnSave = new System.Windows.Forms.Button();
      this.pnlPluginDetails = new System.Windows.Forms.Panel();
      this.btnLoadSprEan = new System.Windows.Forms.Button();
      this.btnOpenSprFile = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtImportSprEan = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtDatasource = new System.Windows.Forms.TextBox();
      this.btnCreateDatabase = new System.Windows.Forms.Button();
      this.ofdFileBrowse = new System.Windows.Forms.OpenFileDialog();
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.panel1.SuspendLayout();
      this.pnlPluginDetails.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 169);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(318, 21);
      // 
      // btnSave
      // 
      this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.btnSave.Location = new System.Drawing.Point(0, 0);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(318, 21);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Выйти";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // pnlPluginDetails
      // 
      this.pnlPluginDetails.BackColor = System.Drawing.Color.White;
      this.pnlPluginDetails.Controls.Add(this.btnLoadSprEan);
      this.pnlPluginDetails.Controls.Add(this.btnOpenSprFile);
      this.pnlPluginDetails.Controls.Add(this.label1);
      this.pnlPluginDetails.Controls.Add(this.txtImportSprEan);
      this.pnlPluginDetails.Controls.Add(this.label6);
      this.pnlPluginDetails.Controls.Add(this.txtDatasource);
      this.pnlPluginDetails.Controls.Add(this.btnCreateDatabase);
      this.pnlPluginDetails.Location = new System.Drawing.Point(8, 3);
      this.pnlPluginDetails.Name = "pnlPluginDetails";
      this.pnlPluginDetails.Size = new System.Drawing.Size(307, 136);
      // 
      // btnLoadSprEan
      // 
      this.btnLoadSprEan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnLoadSprEan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.btnLoadSprEan.Location = new System.Drawing.Point(3, 101);
      this.btnLoadSprEan.Name = "btnLoadSprEan";
      this.btnLoadSprEan.Size = new System.Drawing.Size(136, 20);
      this.btnLoadSprEan.TabIndex = 7;
      this.btnLoadSprEan.Text = "Загрузить";
      this.btnLoadSprEan.Click += new System.EventHandler(this.btnLoadSprEan_Click);
      // 
      // btnOpenSprFile
      // 
      this.btnOpenSprFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnOpenSprFile.Location = new System.Drawing.Point(267, 81);
      this.btnOpenSprFile.Name = "btnOpenSprFile";
      this.btnOpenSprFile.Size = new System.Drawing.Size(39, 19);
      this.btnOpenSprFile.TabIndex = 6;
      this.btnOpenSprFile.Text = "...";
      this.btnOpenSprFile.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(3, 62);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(234, 16);
      this.label1.Text = "Путь к справочнику препаратов";
      // 
      // txtImportSprEan
      // 
      this.txtImportSprEan.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
      this.txtImportSprEan.Location = new System.Drawing.Point(3, 81);
      this.txtImportSprEan.Name = "txtImportSprEan";
      this.txtImportSprEan.Size = new System.Drawing.Size(263, 19);
      this.txtImportSprEan.TabIndex = 3;
      // 
      // label6
      // 
      this.label6.Enabled = false;
      this.label6.Location = new System.Drawing.Point(5, 1);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(234, 16);
      this.label6.Text = "Выбирите БД или создайте новую";
      // 
      // txtDatasource
      // 
      this.txtDatasource.Enabled = false;
      this.txtDatasource.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
      this.txtDatasource.Location = new System.Drawing.Point(3, 20);
      this.txtDatasource.Name = "txtDatasource";
      this.txtDatasource.Size = new System.Drawing.Size(263, 19);
      this.txtDatasource.TabIndex = 1;
      // 
      // btnCreateDatabase
      // 
      this.btnCreateDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnCreateDatabase.Enabled = false;
      this.btnCreateDatabase.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
      this.btnCreateDatabase.Location = new System.Drawing.Point(3, 40);
      this.btnCreateDatabase.Name = "btnCreateDatabase";
      this.btnCreateDatabase.Size = new System.Drawing.Size(136, 20);
      this.btnCreateDatabase.TabIndex = 0;
      this.btnCreateDatabase.Text = "Создать";
      this.btnCreateDatabase.Click += new System.EventHandler(this.btnCreateDatabase_Click);
      // 
      // ofdFileBrowse
      // 
      this.ofdFileBrowse.FileName = "openFileDialog1";
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 145);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(318, 24);
      // 
      // ConfigurePlugin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.ClientSize = new System.Drawing.Size(318, 190);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.pnlPluginDetails);
      this.Controls.Add(this.panel1);
      this.Name = "ConfigurePlugin";
      this.Text = "Опции БД";
      this.panel1.ResumeLayout(false);
      this.pnlPluginDetails.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Panel pnlPluginDetails;
    private System.Windows.Forms.TextBox txtDatasource;
    private System.Windows.Forms.Button btnCreateDatabase;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.OpenFileDialog ofdFileBrowse;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtImportSprEan;
    private System.Windows.Forms.Button btnLoadSprEan;
    private System.Windows.Forms.Button btnOpenSprFile;
    private System.Windows.Forms.StatusBar statusBar;
  }
}