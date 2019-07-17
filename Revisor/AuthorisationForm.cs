using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;

namespace BarcodeFramework
{
  public partial class AuthorisationForm : Form
  {
    private IDataLibPlugin data = GlobalArea.PluginManager.GetActivePlugin();

    public Employee selectedEmp { get { return (Employee)this.cmbEmployees.SelectedItem; }}


    public AuthorisationForm()
    {
      InitializeComponent();
      InitComboList();
      this.cmbEmployees.Focus();
      this.cmbEmployees.SelectedIndexChanged += this.cmbEmployees_SelectedIndexChanged;      
    }

    void InitComboList()
    {
      List<Employee> employees = new List<Employee>();
      employees.AddRange(data.GetEmployees());
      cmbEmployees.DataSource = employees;
      cmbEmployees.DisplayMember = "Name";
      cmbEmployees.ValueMember = "GammaID";
      cmbEmployees.SelectedIndex = 0;
      cmbEmployees.Focus();
    }

    void cmbEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
      GlobalArea.CurrentEmployee = (Employee)this.cmbEmployees.SelectedItem;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      //this.Close();
    }

    private void AuthorisationForm_Closing(object sender, CancelEventArgs e)
    {
      barcoder.EnableScanner = false;
      timer.Enabled = false;
    }

    private void barcode_OnScan(Symbol.Barcode2.ScanDataCollection scanDataCollection)
    {
      ScanData scanData = scanDataCollection.GetFirst;
      if (scanData.Result == Results.SUCCESS)
      {
        Employee emp = null;
        try
        {
          emp = data.GetEmployee(scanData.Text);
          if (emp == null)
          {
            MessageBox.Show("Пользователь с ШК ." + scanData.Text, "Не найден!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            return;
          }
        }
        catch (Exception e)
        {
          MessageBox.Show("Пользователь с ШК ." + scanData.Text, "Не найден!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
          return;
        }       
        setPositionIn_cmbEmployees(emp);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      GlobalArea.CurrentEmployee = selectedEmp;
    }
    private void setPositionIn_cmbEmployees(Employee emp)
    {
      foreach (Employee item in (List<Employee>)cmbEmployees.DataSource)
      {
        if (item.CompareTo(emp) == 0)
        {
          cmbEmployees.SelectedIndex = cmbEmployees.Items.IndexOf(item);
          btOk.Focus();
          return;
        }
      }
      cmbEmployees.Refresh();
    }

    private void label1_ParentChanged(object sender, EventArgs e)
    {

    }

    private void cmbEmployees_SelectedIndexChanged_1(object sender, EventArgs e)
    {

    }

    private void timer_Tick(object sender, EventArgs e)
    {
      DateTime dt = DateTime.Now;
      lbDate.Text = string.Format(@"{0}.{1}.{2}", dt.Day.ToString("00"), dt.Month.ToString("00"), dt.Year);
      lbTime.Text = string.Format(@"{0}:{1}:{2}", dt.Hour.ToString("00"), dt.Minute.ToString("00"), dt.Second.ToString("00"));
    }

    private void AuthorisationForm_Activated(object sender, EventArgs e)
    {
      barcoder.EnableScanner = true;
      lbError.Visible = (GlobalArea.DbInfo.CreatedDBDt > DateTime.Now);
      btOk.Enabled = !lbError.Visible;
      timer.Enabled = true;

    }

    private void AuthorisationForm_Deactivate(object sender, EventArgs e)
    {
      barcoder.EnableScanner = false;
    }
  }
}