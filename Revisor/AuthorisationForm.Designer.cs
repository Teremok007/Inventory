namespace BarcodeFramework
{
  partial class AuthorisationForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.cmbEmployees = new System.Windows.Forms.ComboBox();
      this.btOk = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.barcoder = new Symbol.Barcode2.Design.Barcode2();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(14, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(213, 20);
      this.label1.Text = "Выберите пользователя:";
      // 
      // cmbEmployees
      // 
      this.cmbEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbEmployees.Location = new System.Drawing.Point(14, 36);
      this.cmbEmployees.Name = "cmbEmployees";
      this.cmbEmployees.Size = new System.Drawing.Size(213, 23);
      this.cmbEmployees.TabIndex = 1;
      // 
      // btOk
      // 
      this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btOk.Location = new System.Drawing.Point(14, 173);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(75, 31);
      this.btOk.TabIndex = 3;
      this.btOk.Text = "OK";
      this.btOk.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Location = new System.Drawing.Point(152, 173);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 31);
      this.button2.TabIndex = 4;
      this.button2.Text = "Отмена";
      this.button2.Click += new System.EventHandler(this.button2_Click);
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
      this.barcoder.Config.ScanParameters.BeepFrequency = 2670;
      this.barcoder.Config.ScanParameters.BeepTime = 200;
      this.barcoder.Config.ScanParameters.CodeIdType = Symbol.Barcode2.Design.CodeIdTypes.Default;
      this.barcoder.Config.ScanParameters.LedTime = 3000;
      this.barcoder.Config.ScanParameters.ScanType = Symbol.Barcode2.Design.SCANTYPES.Default;
      this.barcoder.Config.ScanParameters.WaveFile = "";
      this.barcoder.DeviceType = Symbol.Barcode2.DEVICETYPES.FIRSTAVAILABLE;
      this.barcoder.EnableScanner = false;
      this.barcoder.OnScan += new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler(this.barcode_OnScan);
      // 
      // AuthorisationForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(238, 215);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btOk);
      this.Controls.Add(this.cmbEmployees);
      this.Controls.Add(this.label1);
      this.MinimizeBox = false;
      this.Name = "AuthorisationForm";
      this.Text = "Авторизация";
      this.Activated += new System.EventHandler(this.AuthorisationForm_Activated);
      this.Closing += new System.ComponentModel.CancelEventHandler(this.AuthorisationForm_Closing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbEmployees;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Button button2;
    private Symbol.Barcode2.Design.Barcode2 barcoder;
  }
}