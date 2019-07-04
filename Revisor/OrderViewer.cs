using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;
using System.Reflection;

namespace BarcodeFramework
{
  enum TaskType { SCAN_TYPE, EDIT_TYPE }
  public partial class OrderViewer : Form
  {
    private static string DBPath { get { return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); } }
    private static string ScanOrdersFile = "ScanOrders.cvs";
    private static string FullFileName = DBPath + "\\" + ScanOrdersFile;
    private TaskType tt;
    private TaskType taskType { get { return tt; } set { tt = value; TypeBtnColor();  RefreshStatusBar(); } }
    private MultipleQty scanType
    {
      get
      {
        return GlobalArea.AppOption.MultypleQtyType;
      }
      set
      {
        GlobalArea.AppOption.MultypleQtyType = value;
        RefreshScanTypeLabel();
      }
    }

    private void RefreshScanTypeLabel()
    {
      lblPieceScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lblPackageScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));

      lblPieceScanType.ForeColor = Color.Gray;
      lblPackageScanType.ForeColor = Color.Gray;
      switch (GlobalArea.AppOption.MultypleQtyType)
      {
        case MultipleQty.BY_PACKAGE:
          lblPackageScanType.ForeColor = Color.IndianRed;
          lblPackageScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
          break;
        case MultipleQty.BY_PIECE:
          lblPieceScanType.ForeColor = Color.IndianRed;
          lblPieceScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
          break;
      }
    }
    //private Order order;
    private OrderItem lastOrderItem { 
      set 
      {
        if (value == null)
        {
          ClearFields();
          return;
        }
        lbNds.Text = value.Ean.Nds.ToString() + "%";
        lbBarcode.Text = value.Ean.Ean13;
        lbArtCode.Text  = value.ArtCode.ToString();
        lbQty.Text = value.Qty.ToString();
        lblKoef.Text = value.Ean.Koef.ToString();
        lbControlQty.Text = value.Ean.ControlQty.ToString();
        lblDetails.Text = string.Format("{0}\n{1}", value.Ean.Name, value.Ean.Manufacturer);
        //lbManufacturer.Text = value.Ean.Manufacturer;
        if ((GlobalArea.AppOption.IsMoreQtyMessage) && (value.Qty > value.Ean.ControlQty))
        {
          ShowMessageIfMoreQty(String.Format("Кол-во сканированого {0} превышает в аптеке {1}", 
                                             value.Qty.ToString(),
                                             value.Ean.ControlQty.ToString()));
        }
        RefreshFont();
      } 
    }
    private IDataLibPlugin data;
    private StringBuilder handyBarcode = new StringBuilder();
    public OrderViewer()
    {
      InitializeComponent();
      // Заголовок формы
      this.Text = string.Format("{0}|({1}){2}", 
                                GlobalArea.DbInfo.PereuchetDateText, 
                                GlobalArea.DbInfo.AptekaID, 
                                GlobalArea.DbInfo.AptekaName);
      data = GlobalArea.PluginManager.GetActivePlugin();
//      this.order = data.GetOrder();
//      this.order.AddedMore += ShowMessageIfMoreQty;
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HotKeys);      
      btnScan.Focus();
      taskType = TaskType.SCAN_TYPE;
      this.lastOrderItem = null;      
      barcoder.EnableScanner = true;
      GlobalArea.AppOption.AppOptionChanged += ChangedOptionAction;
      lbPackageFlag.ForeColor = (GlobalArea.AppOption.FastScan) ? Color.IndianRed : Color.Gray;
      lbEmployerName.Text = (GlobalArea.CurrentEmployee != null) ? GlobalArea.CurrentEmployee.Name : "";
    }
    
    private void HotKeys(object sender,  System.Windows.Forms.KeyPressEventArgs e)
    {
    }

    private void myBarcode2_StatusNotify(StatusData statusData)
    {
      //switch (statusData.State)
      //{
      //  case States.IDLE:

      //    if (currentListView == SCAN)
      //      statusBar.Text = "Press trigger to scan";
      //    else if (currentListView == SCAN_CONTINUOUS)
      //      statusBar.Text = "Aim at barcode to scan";
      //    break;

      //  case States.READY:
      //    if ((currentListView == SCAN) || (currentListView == SCAN_CONTINUOUS))
      //      statusBar.Text = "Aim at barcode to scan";
      //    break;

      //  default:
      //    statusBar.Text = statusData.Text;
      //    break;
      //}
    }

    private void EditingData(string barcode)
    {
      OrderItem item = data.GetOrdeItemByBarcode(barcode);
      if (item == null)
      {
        MessageBox.Show("Запись с ШК " + barcode + " не найдена.", "Внимание...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        lastOrderItem = null;
        RefreshStatusBar();
        return;
      }
      using(EditOrderItem editForm = new EditOrderItem(item))
      {
        if (editForm.ShowDialog() == DialogResult.OK)
        {
          data.Save(ref item);
          lastOrderItem = item;
          taskType = TaskType.SCAN_TYPE;
          btnScan.Focus();
          RefreshStatusBar();
        }
      }
    }

    private void ScaningData(string barcode)
    {
      OrderItem item = null;
        try
        {
          //если в сканированых не  нашли тогда ищем в БД          
          statusBar1.Text = "Поиск " + barcode + " в БД...";
          statusBar1.Refresh();
          item = data.GetOrdeItemByBarcode(barcode);
          // запись не создана тогда создадим её
          if (item == null)
          {
            item = data.CreateOrderItemByBarcode(barcode);
            //если ШК не найден то выход
            
          }

          if (item == null)
          {
            statusBar1.Text = "ШК " + barcode + " не найден.";
            MessageBox.Show(statusBar1.Text, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            RefreshStatusBar();
            return;
          }
          try
          {
            if (GlobalArea.AppOption.FastScan)
            {
              item.Qty += ((GlobalArea.AppOption.MultypleQtyType == MultipleQty.BY_PACKAGE) ? item.Ean.Koef : 1);
              var t_itm = data.Save(ref item);
              lastOrderItem = t_itm;
              if (t_itm == null)
              {
                MessageBox.Show("Позиция не добавлена", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
              }
            }
            else using (EditQty editQty = new EditQty())
              {
                editQty.Text = "Ввод количества | " + barcode;
                editQty.Ean13 = barcode;
                var listOrderItem = new List<OrderItem>();

                listOrderItem.Add(item);
                editQty.cbArt.DataSource = listOrderItem;
                editQty.cbArt.DisplayMember = "Name";
                editQty.cbArt.ValueMember = "ArtCode";
                editQty.cbArt.SelectedIndex = 0;
                editQty.cbArt.Focus();
                editQty.lblCnt.Text = editQty.cbArt.Items.Count.ToString();
                if (editQty.cbArt.Items.Count == 1)
                {
                  editQty.tbQty.Focus();
                  editQty.tbQty.SelectAll();
                }
                if ((editQty.ShowDialog() == DialogResult.OK) && (editQty.Qty != 0))
                {
                  item.Qty += editQty.Qty;
                  lastOrderItem = data.Save(ref item);
                }
              }
          }
          catch (Exception e)
          {
            MessageBox.Show(statusBar1.Text, "Ошибка записи данных в БД.", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
          }
        }         
        finally
        {
          RefreshStatusBar();
        }
      }

    private void button1_Click(object sender, EventArgs e)
    {      
      this.Close();
    }

    private void barcoder_OnScan(ScanDataCollection scanDataCollection)    
    {
      if (GlobalArea.CurrentEmployee == null)
      {
        MessageBox.Show("Выберите пользователя и продолжайте сканирование.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        return;
      }
      if (handyBarcode.ToString().Length > 0)
      {
        handyBarcode.Remove(0, handyBarcode.Length);
      }
      ScanData scanData = scanDataCollection.GetFirst;
      if (scanData.Result == Results.SUCCESS)
      {
        DoScan(scanData.Text);
      }
    }
    
    private void barcoder_OnStatus(StatusData statusData)
    {

    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      taskType = TaskType.EDIT_TYPE;
    }

    private void ShowMessageIfMoreQty(string message)
    {
      if (GlobalArea.AppOption.IsMoreQtyMessage)
      {
        MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Эта функция не поддерживается.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
    }

    private void btnScan_Click(object sender, EventArgs e)
    {
      taskType = TaskType.SCAN_TYPE;
    }

    private void OrderViewer_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F2)
      {
        btnScan.Focus();
        btnScan_Click(btnScan, EventArgs.Empty);
      }
      if (e.KeyCode == Keys.F3)
      {
        btnEdit.Focus();
        btnEdit_Click(btnEdit, EventArgs.Empty);
      }
      if (e.KeyCode == Keys.F8)
      {
        btnExport.Focus();
        btnExport_Click(btnExport, EventArgs.Empty);
      }
      if (e.KeyCode == Keys.Left)
      {
        GlobalArea.AppOption.MultypleQtyType = GetPrevScanType();
        e.Handled = true;
      }
      if (e.KeyCode == Keys.Right)
      {
        GlobalArea.AppOption.MultypleQtyType = GetNextScanType();
        e.Handled = true;
      }
      if ((e.KeyCode == Keys.Return) && (handyBarcode.Length > 0))
      {
        DoScan(handyBarcode.ToString());
        e.Handled = true;
      }
    }

    private void OrderViewer_KeyPress(object sender, KeyPressEventArgs e)
    {
      List<int> numbers = new List<int>(new int[]{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
      if (numbers.Exists(x => x == e.KeyChar))
      {
        handyBarcode.Append(e.KeyChar);
        if (handyBarcode.Length == 13)
        {
          DoScan(handyBarcode.ToString());
          handyBarcode.Remove(0, handyBarcode.Length);
        }
        RefreshStatusBar();
      }
      //if ((e.KeyChar == Convert.ToChar(Keys.Return)) && (handyBarcode.Length > 0))
      //{
      //  DoScan(handyBarcode.ToString());
      //}
      if (e.KeyChar == Convert.ToChar(Keys.Back))
      {
        if (handyBarcode.Length > 0)
        {
          handyBarcode.Remove(handyBarcode.Length - 1, 1);
          RefreshStatusBar();
        }
      }

    }

    private void RefreshStatusBar() 
    {
      statusBar1.Text = string.Format("{0}  |  {1}",
        ((taskType == TaskType.EDIT_TYPE) ? "Правка..." : "Добавление..."),
        handyBarcode.ToString());

      ScanInfo scanInfo = data.GetScanInfo(0);
      sbStatistics.Text = string.Format("Препаратов: {0}  | Кол-во {1}", scanInfo.Count, scanInfo.SumQty);
    }

    private void DoScan(string barcode)
    {
      switch (taskType)
      {
        case TaskType.SCAN_TYPE:
          ScaningData(barcode);
          break;
        case TaskType.EDIT_TYPE:
          EditingData(barcode);
          break;
      }
    }

    private void TypeBtnColor()
    {
      btnScan.BackColor = (taskType == TaskType.SCAN_TYPE) ? Color.FromArgb(255, 128, 128) : Color.FromArgb(224, 224, 224);
      btnEdit.BackColor = (taskType == TaskType.EDIT_TYPE) ? Color.FromArgb(255, 128, 128) : Color.FromArgb(224, 224, 224);
    }

    private void btOption_Click(object sender, EventArgs e)
    {
      using (OptionsView optionsView = new OptionsView())
      {
        if (optionsView.ShowDialog() == DialogResult.OK)
        {
          //lblPieceScanType.sefff
        }
        optionsView.Close();
      }
    }

    private void ClearFields()
    {
      lblDetails.Text = "";
//      lbManufacturer.Text = "";
      lbQty.Text = "";
      lblKoef.Text = "";
      lbControlQty.Text = "";
      lbNds.Text = "";
      lbBarcode.Text = "";
      lbArtCode.Text = "";
    }

    private void OrderViewer_Closed(object sender, EventArgs e)
    {
      GlobalArea.AppOption.AppOptionChanged -= ChangedOptionAction;
      barcoder.EnableScanner = false;
    }
    
    private void btnExport_Click(object sender, EventArgs e)
    {
      // выключим сканер на время сохраннения данных
      barcoder.EnableScanner = false;
      try
      {
        data.ScanExport("");
        MessageBox.Show("Выгрузка выполнена.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      finally
      {
        barcoder.EnableScanner = true;
      }
    }

    private void panel1_GotFocus(object sender, EventArgs e)
    {

    }

    private MultipleQty GetNextScanType()
    {
      return (GlobalArea.AppOption.MultypleQtyType == MultipleQty.BY_PACKAGE) ? MultipleQty.BY_PIECE : MultipleQty.BY_PACKAGE;
    }

    private MultipleQty GetPrevScanType()
    {// т.к. всего режима сканирования два, то GetNextScanType и GetPrevScanType одинаковы
      return (GlobalArea.AppOption.MultypleQtyType == MultipleQty.BY_PACKAGE) ? MultipleQty.BY_PIECE : MultipleQty.BY_PACKAGE;
    }

    private void ChangedOptionAction(AppOption options)
    {           
      lblPieceScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lblPackageScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));

      lblPieceScanType.ForeColor = Color.Gray;
      lblPackageScanType.ForeColor = Color.Gray;      
      switch (options.MultypleQtyType)
      {
        case MultipleQty.BY_PACKAGE:
          lblPackageScanType.ForeColor = Color.IndianRed;
          lblPackageScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
          break;
        case MultipleQty.BY_PIECE:
          lblPieceScanType.ForeColor = Color.IndianRed;
          lblPieceScanType.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
          break;
      }

      lbPackageFlag.ForeColor = (options.FastScan) ? Color.IndianRed : Color.Gray; 
    }

    private void lblPackageScanType_Click(object sender, EventArgs e)
    {
      GlobalArea.AppOption.MultypleQtyType = MultipleQty.BY_PACKAGE;
    }

    private void lblPieceScanType_Click(object sender, EventArgs e)
    {
      GlobalArea.AppOption.MultypleQtyType = MultipleQty.BY_PIECE;
    }

    private void lbPackageFlag_Click(object sender, EventArgs e)
    {
      GlobalArea.AppOption.FastScan = !GlobalArea.AppOption.FastScan;
    }

    private void lbEmployerName_Click(object sender, EventArgs e)
    {
      barcoder.EnableScanner = false;
      try
      {
        using (AuthorisationForm auth = new AuthorisationForm())
        {
          if (auth.ShowDialog() == DialogResult.OK)
          {
            lbEmployerName.Text = (GlobalArea.CurrentEmployee != null) ? GlobalArea.CurrentEmployee.Name : "";
          }
        }
      }
      finally
      {
        barcoder.EnableScanner = true;
        RefreshStatusBar();
      }
    }

    private void RefreshFont()
    {
      RefreshScanTypeLabel();
      lblDetails.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbQty.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lblKoef.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbControlQty.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbNds.Font = new System.Drawing.Font("Tahoma", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Regular))));
      label1.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      label2.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      label4.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
      lbArtCode.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))));
    }

    private void OrderViewer_GotFocus(object sender, EventArgs e)
    {
      RefreshFont();
    }

    private void OrderViewer_Activated(object sender, EventArgs e)
    {
      RefreshFont();
    }

    private void OrderViewer_Resize(object sender, EventArgs e)
    {
      RefreshFont();
    }
  }
}