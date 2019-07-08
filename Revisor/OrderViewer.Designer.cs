namespace BarcodeFramework
{
  partial class OrderViewer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderViewer));
      this.imageList = new System.Windows.Forms.ImageList();
      this.panel1 = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.btnExport = new System.Windows.Forms.Button();
      this.btnEdit = new System.Windows.Forms.Button();
      this.btnScan = new System.Windows.Forms.Button();
      this.barcoder = new Symbol.Barcode2.Design.Barcode2();
      this.statusBar1 = new System.Windows.Forms.StatusBar();
      this.pnTask = new System.Windows.Forms.Panel();
      this.lbEmployerName = new System.Windows.Forms.LinkLabel();
      this.lblKoef = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lbPackageFlag = new System.Windows.Forms.LinkLabel();
      this.lblPieceScanType = new System.Windows.Forms.LinkLabel();
      this.lblPackageScanType = new System.Windows.Forms.LinkLabel();
      this.lbControlQty = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btOption = new System.Windows.Forms.Button();
      this.lbBarcode = new System.Windows.Forms.Label();
      this.lbNds = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lbArtCode = new System.Windows.Forms.Label();
      this.lbQty = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lblDetails = new System.Windows.Forms.Label();
      this.OrdersTable = new System.Data.DataTable();
      this.dataColumn1 = new System.Data.DataColumn();
      this.dataColumn2 = new System.Data.DataColumn();
      this.dataColumn3 = new System.Data.DataColumn();
      this.dataColumn4 = new System.Data.DataColumn();
      this.sbStatistics = new System.Windows.Forms.StatusBar();
      this.panel1.SuspendLayout();
      this.pnTask.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).BeginInit();
      this.SuspendLayout();
      this.imageList.Images.Clear();
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
      this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.btnExport);
      this.panel1.Controls.Add(this.btnEdit);
      this.panel1.Controls.Add(this.btnScan);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 247);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(238, 28);
      this.panel1.GotFocus += new System.EventHandler(this.panel1_GotFocus);
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.button1.Dock = System.Windows.Forms.DockStyle.Left;
      this.button1.Location = new System.Drawing.Point(168, 0);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(67, 28);
      this.button1.TabIndex = 3;
      this.button1.Text = "Exit";
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btnExport
      // 
      this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnExport.ForeColor = System.Drawing.Color.Black;
      this.btnExport.Location = new System.Drawing.Point(109, 0);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new System.Drawing.Size(59, 28);
      this.btnExport.TabIndex = 2;
      this.btnExport.Text = "Export";
      this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
      // 
      // btnEdit
      // 
      this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnEdit.Location = new System.Drawing.Point(54, 0);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(55, 28);
      this.btnEdit.TabIndex = 1;
      this.btnEdit.Text = "Edit F3";
      this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
      // 
      // btnScan
      // 
      this.btnScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnScan.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnScan.Location = new System.Drawing.Point(0, 0);
      this.btnScan.Name = "btnScan";
      this.btnScan.Size = new System.Drawing.Size(54, 28);
      this.btnScan.TabIndex = 0;
      this.btnScan.Text = "Add F2";
      this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
      // 
      // barcoder
      // 
      this.barcoder.Config.DecoderParameters.CODABAR = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.CODABARParams.ClsiEditing = false;
      this.barcoder.Config.DecoderParameters.CODABARParams.NotisEditing = false;
      this.barcoder.Config.DecoderParameters.CODABARParams.Redundancy = true;
      this.barcoder.Config.DecoderParameters.CODE128 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.CODE128Params.EAN128 = true;
      this.barcoder.Config.DecoderParameters.CODE128Params.ISBT128 = true;
      this.barcoder.Config.DecoderParameters.CODE128Params.Other128 = true;
      this.barcoder.Config.DecoderParameters.CODE128Params.Redundancy = false;
      this.barcoder.Config.DecoderParameters.CODE39 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.CODE39Params.Code32Prefix = false;
      this.barcoder.Config.DecoderParameters.CODE39Params.Concatenation = false;
      this.barcoder.Config.DecoderParameters.CODE39Params.ConvertToCode32 = false;
      this.barcoder.Config.DecoderParameters.CODE39Params.FullAscii = false;
      this.barcoder.Config.DecoderParameters.CODE39Params.Redundancy = false;
      this.barcoder.Config.DecoderParameters.CODE39Params.ReportCheckDigit = false;
      this.barcoder.Config.DecoderParameters.CODE39Params.VerifyCheckDigit = false;
      this.barcoder.Config.DecoderParameters.CODE93 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.CODE93Params.Redundancy = false;
      this.barcoder.Config.DecoderParameters.D2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.D2OF5Params.Redundancy = true;
      this.barcoder.Config.DecoderParameters.EAN13 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.EAN8 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.EAN8Params.ConvertToEAN13 = false;
      this.barcoder.Config.DecoderParameters.I2OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.I2OF5Params.ConvertToEAN13 = false;
      this.barcoder.Config.DecoderParameters.I2OF5Params.Redundancy = true;
      this.barcoder.Config.DecoderParameters.I2OF5Params.ReportCheckDigit = false;
      this.barcoder.Config.DecoderParameters.I2OF5Params.VerifyCheckDigit = Symbol.Barcode2.Design.I2OF5.CheckDigitSchemes.Default;
      this.barcoder.Config.DecoderParameters.KOREAN_3OF5 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.KOREAN_3OF5Params.Redundancy = true;
      this.barcoder.Config.DecoderParameters.MSI = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode2.Design.CheckDigitCounts.Default;
      this.barcoder.Config.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode2.Design.CheckDigitSchemes.Default;
      this.barcoder.Config.DecoderParameters.MSIParams.Redundancy = true;
      this.barcoder.Config.DecoderParameters.MSIParams.ReportCheckDigit = false;
      this.barcoder.Config.DecoderParameters.UPCA = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode2.Design.Preambles.Default;
      this.barcoder.Config.DecoderParameters.UPCAParams.ReportCheckDigit = true;
      this.barcoder.Config.DecoderParameters.UPCE0 = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.DecoderParameters.UPCE0Params.ConvertToUPCA = false;
      this.barcoder.Config.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode2.Design.Preambles.Default;
      this.barcoder.Config.DecoderParameters.UPCE0Params.ReportCheckDigit = false;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Symbol.Barcode2.Design.DPM_MODE.DPM_MODE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Symbol.Barcode2.Design.FOCUS_MODE.FOCUS_MODE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Symbol.Barcode2.Design.FOCUS_POSITION.FOCUS_POSITION_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Symbol.Barcode2.Design.ILLUMINATION_MODE.ILLUMINATION_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Symbol.Barcode2.Design.INVERSE1D_MODE.INVERSE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Symbol.Barcode2.Design.PICKLIST_MODE.PICKLIST_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Symbol.Barcode2.Design.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Symbol.Barcode2.Design.VIEWFINDER_MODE.VIEWFINDER_MODE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Symbol.Barcode2.Design.AIM_MODE.AIM_MODE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Symbol.Barcode2.Design.AIM_TYPE.AIM_TYPE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BeamWidth = Symbol.Barcode2.Design.BEAM_WIDTH.DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Symbol.Barcode2.Design.DBP_MODE.DBP_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Symbol.Barcode2.Design.LINEAR_SECURITY_LEVEL.SECURITY_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Symbol.Barcode2.Design.RASTER_MODE.RASTER_MODE_DEFAULT;
      this.barcoder.Config.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Symbol.Barcode2.Design.DisabledEnabled.Default;
      this.barcoder.Config.ScanParameters.BeepFrequency = 1000;
      this.barcoder.Config.ScanParameters.BeepTime = 100;
      this.barcoder.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.Default;
      this.barcoder.Config.ScanParameters.LedTime = 3000;
      this.barcoder.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.Default;
      this.barcoder.Config.ScanParameters.WaveFile = "";
      this.barcoder.DeviceType = Symbol.Barcode2.DEVICETYPES.FIRSTAVAILABLE;
      this.barcoder.EnableScanner = false;
      this.barcoder.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.barcoder_OnScan);
      // 
      // statusBar1
      // 
      this.statusBar1.Location = new System.Drawing.Point(0, 223);
      this.statusBar1.Name = "statusBar1";
      this.statusBar1.Size = new System.Drawing.Size(238, 24);
      this.statusBar1.Text = "statusBar1";
      // 
      // pnTask
      // 
      this.pnTask.Controls.Add(this.lbEmployerName);
      this.pnTask.Controls.Add(this.lblKoef);
      this.pnTask.Controls.Add(this.label2);
      this.pnTask.Controls.Add(this.lbPackageFlag);
      this.pnTask.Controls.Add(this.lblPieceScanType);
      this.pnTask.Controls.Add(this.lblPackageScanType);
      this.pnTask.Controls.Add(this.lbControlQty);
      this.pnTask.Controls.Add(this.label4);
      this.pnTask.Controls.Add(this.btOption);
      this.pnTask.Controls.Add(this.lbBarcode);
      this.pnTask.Controls.Add(this.lbNds);
      this.pnTask.Controls.Add(this.label5);
      this.pnTask.Controls.Add(this.lbArtCode);
      this.pnTask.Controls.Add(this.lbQty);
      this.pnTask.Controls.Add(this.label1);
      this.pnTask.Controls.Add(this.lblDetails);
      this.pnTask.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnTask.Location = new System.Drawing.Point(0, 0);
      this.pnTask.Name = "pnTask";
      this.pnTask.Size = new System.Drawing.Size(238, 198);
      // 
      // lbEmployerName
      // 
      this.lbEmployerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lbEmployerName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
      this.lbEmployerName.ForeColor = System.Drawing.Color.RoyalBlue;
      this.lbEmployerName.Location = new System.Drawing.Point(1, 179);
      this.lbEmployerName.Name = "lbEmployerName";
      this.lbEmployerName.Size = new System.Drawing.Size(234, 18);
      this.lbEmployerName.TabIndex = 54;
      this.lbEmployerName.Text = "Ещенко Сергей Михайлович";
      this.lbEmployerName.Click += new System.EventHandler(this.lbEmployerName_Click);
      // 
      // lblKoef
      // 
      this.lblKoef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblKoef.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
      this.lblKoef.Location = new System.Drawing.Point(163, 101);
      this.lblKoef.Name = "lblKoef";
      this.lblKoef.Size = new System.Drawing.Size(72, 25);
      this.lblKoef.Text = "5555";
      this.lblKoef.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(133, 108);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 21);
      this.label2.Text = "Кф:";
      // 
      // lbPackageFlag
      // 
      this.lbPackageFlag.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.lbPackageFlag.ForeColor = System.Drawing.Color.Gray;
      this.lbPackageFlag.Location = new System.Drawing.Point(78, 1);
      this.lbPackageFlag.Name = "lbPackageFlag";
      this.lbPackageFlag.Size = new System.Drawing.Size(49, 17);
      this.lbPackageFlag.TabIndex = 41;
      this.lbPackageFlag.Text = "АВТО";
      this.lbPackageFlag.Click += new System.EventHandler(this.lbPackageFlag_Click);
      // 
      // lblPieceScanType
      // 
      this.lblPieceScanType.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.lblPieceScanType.ForeColor = System.Drawing.Color.Gray;
      this.lblPieceScanType.Location = new System.Drawing.Point(5, 1);
      this.lblPieceScanType.Name = "lblPieceScanType";
      this.lblPieceScanType.Size = new System.Drawing.Size(32, 17);
      this.lblPieceScanType.TabIndex = 25;
      this.lblPieceScanType.Text = "ШТ";
      this.lblPieceScanType.Click += new System.EventHandler(this.lblPieceScanType_Click);
      // 
      // lblPackageScanType
      // 
      this.lblPackageScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
      this.lblPackageScanType.ForeColor = System.Drawing.Color.IndianRed;
      this.lblPackageScanType.Location = new System.Drawing.Point(43, 1);
      this.lblPackageScanType.Name = "lblPackageScanType";
      this.lblPackageScanType.Size = new System.Drawing.Size(29, 17);
      this.lblPackageScanType.TabIndex = 24;
      this.lblPackageScanType.Text = "УП";
      this.lblPackageScanType.Click += new System.EventHandler(this.lblPackageScanType_Click);
      // 
      // lbControlQty
      // 
      this.lbControlQty.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
      this.lbControlQty.Location = new System.Drawing.Point(78, 132);
      this.lbControlQty.Name = "lbControlQty";
      this.lbControlQty.Size = new System.Drawing.Size(66, 24);
      this.lbControlQty.Text = "1999";
      this.lbControlQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label4
      // 
      this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label4.Location = new System.Drawing.Point(3, 137);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(83, 19);
      this.label4.Text = "Ост. в апт.";
      // 
      // btOption
      // 
      this.btOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btOption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
      this.btOption.Location = new System.Drawing.Point(166, 0);
      this.btOption.Name = "btOption";
      this.btOption.Size = new System.Drawing.Size(72, 19);
      this.btOption.TabIndex = 10;
      this.btOption.Text = "Настройки";
      this.btOption.Click += new System.EventHandler(this.btOption_Click);
      // 
      // lbBarcode
      // 
      this.lbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbBarcode.Location = new System.Drawing.Point(5, 163);
      this.lbBarcode.Name = "lbBarcode";
      this.lbBarcode.Size = new System.Drawing.Size(106, 15);
      this.lbBarcode.Text = "1234567890123";
      // 
      // lbNds
      // 
      this.lbNds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lbNds.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
      this.lbNds.Location = new System.Drawing.Point(186, 133);
      this.lbNds.Name = "lbNds";
      this.lbNds.Size = new System.Drawing.Size(47, 19);
      this.lbNds.Text = "20%";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
      this.label5.Location = new System.Drawing.Point(155, 137);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(43, 19);
      this.label5.Text = "НДС:";
      // 
      // lbArtCode
      // 
      this.lbArtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lbArtCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
      this.lbArtCode.ForeColor = System.Drawing.Color.Maroon;
      this.lbArtCode.Location = new System.Drawing.Point(129, 163);
      this.lbArtCode.Name = "lbArtCode";
      this.lbArtCode.Size = new System.Drawing.Size(106, 20);
      this.lbArtCode.Text = "32135211";
      this.lbArtCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lbQty
      // 
      this.lbQty.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
      this.lbQty.Location = new System.Drawing.Point(43, 102);
      this.lbQty.Name = "lbQty";
      this.lbQty.Size = new System.Drawing.Size(75, 24);
      this.lbQty.Text = "999999";
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
      this.label1.Location = new System.Drawing.Point(1, 108);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 23);
      this.label1.Text = "Кол:";
      // 
      // lblDetails
      // 
      this.lblDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDetails.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
      this.lblDetails.Location = new System.Drawing.Point(3, 16);
      this.lblDetails.Name = "lblDetails";
      this.lblDetails.Size = new System.Drawing.Size(232, 86);
      this.lblDetails.Text = "съешь ещё этих мягких французских булок, да выпей чаю съешь ещё этих мягких франц" +
          "узских булок, да выпей чаю";
      // 
      // OrdersTable
      // 
      this.OrdersTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
      this.OrdersTable.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
      this.OrdersTable.DisplayExpression = "";
      this.OrdersTable.Prefix = "";
      this.OrdersTable.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn4};
      this.OrdersTable.TableName = "Orders";
      // 
      // dataColumn1
      // 
      this.dataColumn1.Caption = "Код";
      this.dataColumn1.ColumnMapping = System.Data.MappingType.Element;
      this.dataColumn1.ColumnName = "ArtCode";
      this.dataColumn1.DataType = typeof(int);
      this.dataColumn1.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;
      this.dataColumn1.Expression = "";
      this.dataColumn1.Prefix = "";
      this.dataColumn1.ReadOnly = true;
      // 
      // dataColumn2
      // 
      this.dataColumn2.Caption = "Кол-во";
      this.dataColumn2.ColumnMapping = System.Data.MappingType.Element;
      this.dataColumn2.ColumnName = "Qty";
      this.dataColumn2.DataType = typeof(int);
      this.dataColumn2.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;
      this.dataColumn2.Expression = "";
      this.dataColumn2.Prefix = "";
      // 
      // dataColumn3
      // 
      this.dataColumn3.Caption = "Название";
      this.dataColumn3.ColumnMapping = System.Data.MappingType.Element;
      this.dataColumn3.ColumnName = "Name";
      this.dataColumn3.DataType = typeof(string);
      this.dataColumn3.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;
      this.dataColumn3.Expression = "";
      this.dataColumn3.Prefix = "";
      this.dataColumn3.ReadOnly = true;
      // 
      // dataColumn4
      // 
      this.dataColumn4.AllowDBNull = false;
      this.dataColumn4.Caption = "ИД";
      this.dataColumn4.ColumnMapping = System.Data.MappingType.Hidden;
      this.dataColumn4.ColumnName = "Id";
      this.dataColumn4.DataType = typeof(System.Guid);
      this.dataColumn4.DateTimeMode = System.Data.DataSetDateTime.UnspecifiedLocal;
      this.dataColumn4.Expression = "";
      this.dataColumn4.Prefix = "";
      // 
      // sbStatistics
      // 
      this.sbStatistics.Location = new System.Drawing.Point(0, 199);
      this.sbStatistics.Name = "sbStatistics";
      this.sbStatistics.Size = new System.Drawing.Size(238, 24);
      this.sbStatistics.Text = "sbStatistics";
      // 
      // OrderViewer
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(238, 275);
      this.Controls.Add(this.sbStatistics);
      this.Controls.Add(this.pnTask);
      this.Controls.Add(this.statusBar1);
      this.Controls.Add(this.panel1);
      this.KeyPreview = true;
      this.Name = "OrderViewer";
      this.Text = "Документы";
      this.Closed += new System.EventHandler(this.OrderViewer_Closed);
      this.Activated += new System.EventHandler(this.OrderViewer_Activated);
      this.GotFocus += new System.EventHandler(this.OrderViewer_GotFocus);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderViewer_KeyPress);
      this.Resize += new System.EventHandler(this.OrderViewer_Resize);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderViewer_KeyDown);
      this.panel1.ResumeLayout(false);
      this.pnTask.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.OrdersTable)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button button1;
    private Symbol.Barcode2.Design.Barcode2 barcoder;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.Panel pnTask;
    private System.Windows.Forms.Button btnEdit;
    private System.Data.DataTable OrdersTable;
    private System.Data.DataColumn dataColumn1;
    private System.Data.DataColumn dataColumn2;
    private System.Data.DataColumn dataColumn3;
    private System.Data.DataColumn dataColumn4;
    private System.Windows.Forms.Button btnScan;
    private System.Windows.Forms.Label lblDetails;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Label lbQty;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lbArtCode;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lbNds;
    private System.Windows.Forms.Label lbBarcode;
    private System.Windows.Forms.Button btOption;
    private System.Windows.Forms.Label lbControlQty;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblKoef;
    private System.Windows.Forms.StatusBar sbStatistics;
    private System.Windows.Forms.LinkLabel lblPackageScanType;
    private System.Windows.Forms.LinkLabel lblPieceScanType;
    private System.Windows.Forms.LinkLabel lbPackageFlag;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.LinkLabel lbEmployerName;
  }
}