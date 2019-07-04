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

    private void AuthorisationForm_Activated(object sender, EventArgs e)
    {
      barcoder.EnableScanner = true;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void AuthorisationForm_Closing(object sender, CancelEventArgs e)
    {
      barcoder.EnableScanner = false;
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
  }
}