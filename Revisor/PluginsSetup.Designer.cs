namespace BarcodeFramework
{
  partial class PluginsSetup
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsSetup));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnNewPlugin = new System.Windows.Forms.Button();
      this.lvPlugins = new System.Windows.Forms.ListView();
      this.btnRemovePlugin = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 162);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(317, 29);
      // 
      // btnCancel
      // 
      this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnCancel.Location = new System.Drawing.Point(167, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(150, 29);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnSave
      // 
      this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnSave.Location = new System.Drawing.Point(0, 0);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(169, 29);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Сохранить";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(15, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(35, 36);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(56, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(260, 25);
      this.label1.Text = "Выбирите плагин для работы с БД";
      // 
      // btnNewPlugin
      // 
      this.btnNewPlugin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnNewPlugin.Location = new System.Drawing.Point(15, 54);
      this.btnNewPlugin.Name = "btnNewPlugin";
      this.btnNewPlugin.Size = new System.Drawing.Size(107, 22);
      this.btnNewPlugin.TabIndex = 3;
      this.btnNewPlugin.Text = "Новый";
      this.btnNewPlugin.Click += new System.EventHandler(this.btnNewPlugin_Click);
      // 
      // lvPlugins
      // 
      this.lvPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvPlugins.Location = new System.Drawing.Point(15, 82);
      this.lvPlugins.Name = "lvPlugins";
      this.lvPlugins.Size = new System.Drawing.Size(299, 45);
      this.lvPlugins.TabIndex = 4;
      this.lvPlugins.SelectedIndexChanged += new System.EventHandler(this.lvPlugins_SelectedIndexChanged);
      // 
      // btnRemovePlugin
      // 
      this.btnRemovePlugin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
      this.btnRemovePlugin.Location = new System.Drawing.Point(15, 133);
      this.btnRemovePlugin.Name = "btnRemovePlugin";
      this.btnRemovePlugin.Size = new System.Drawing.Size(105, 25);
      this.btnRemovePlugin.TabIndex = 5;
      this.btnRemovePlugin.Text = "Удалить";
      this.btnRemovePlugin.Click += new System.EventHandler(this.btnRemovePlugin_Click);
      // 
      // PluginsSetup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.ClientSize = new System.Drawing.Size(317, 191);
      this.Controls.Add(this.btnRemovePlugin);
      this.Controls.Add(this.lvPlugins);
      this.Controls.Add(this.btnNewPlugin);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.panel1);
      this.Name = "PluginsSetup";
      this.Text = "Настройка плагинов";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnNewPlugin;
    private System.Windows.Forms.ListView lvPlugins;
    private System.Windows.Forms.Button btnRemovePlugin;
  }
}