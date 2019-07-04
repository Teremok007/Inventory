namespace BarcodeFramework
{
  partial class MainMenu
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
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
      this.lstMainMenu = new System.Windows.Forms.ListView();
      this.imageList = new System.Windows.Forms.ImageList();
      this.panel1 = new System.Windows.Forms.Panel();
      this.Logout = new System.Windows.Forms.Button();
      this.statusBar1 = new System.Windows.Forms.StatusBar();
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lstMainMenu
      // 
      this.lstMainMenu.Activation = System.Windows.Forms.ItemActivation.TwoClick;
      this.lstMainMenu.BackColor = System.Drawing.Color.White;
      this.lstMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
      listViewItem1.ImageIndex = 5;
      listViewItem1.Tag = "NewOrder";
      listViewItem1.Text = "Сканировать";
      listViewItem2.ImageIndex = 0;
      listViewItem2.Tag = "Options";
      listViewItem2.Text = "Настройки";
      this.lstMainMenu.Items.Add(listViewItem1);
      this.lstMainMenu.Items.Add(listViewItem2);
      this.lstMainMenu.LargeImageList = this.imageList;
      this.lstMainMenu.Location = new System.Drawing.Point(0, 0);
      this.lstMainMenu.Name = "lstMainMenu";
      this.lstMainMenu.Size = new System.Drawing.Size(638, 455);
      this.lstMainMenu.TabIndex = 0;
      this.lstMainMenu.SelectedIndexChanged += new System.EventHandler(this.lstMainMenu_SelectedIndexChanged);
      // 
      // imageList
      // 
      this.imageList.ImageSize = new System.Drawing.Size(32, 32);
      this.imageList.Images.Clear();
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.Logout);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 424);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(638, 31);
      // 
      // Logout
      // 
      this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.Logout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Logout.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
      this.Logout.ForeColor = System.Drawing.Color.Black;
      this.Logout.Location = new System.Drawing.Point(0, 0);
      this.Logout.Name = "Logout";
      this.Logout.Size = new System.Drawing.Size(638, 31);
      this.Logout.TabIndex = 0;
      this.Logout.Text = "Выход";
      this.Logout.Click += new System.EventHandler(this.Logout_Click);
      // 
      // statusBar1
      // 
      this.statusBar1.Location = new System.Drawing.Point(0, 0);
      this.statusBar1.Name = "statusBar1";
      this.statusBar1.Text = "statusBar1";
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 400);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(638, 24);
      // 
      // MainMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(638, 455);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.lstMainMenu);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainMenu";
      this.Text = "Сканер ШК";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView lstMainMenu;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button Logout;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.StatusBar statusBar;
  }
}