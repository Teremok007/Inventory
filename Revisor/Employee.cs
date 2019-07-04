using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public class Employee : IComparable
  {
    public int GammaID { get; set; }
    public string Barcode { get; set; }
    public string Name { get; set; }

    #region IComparable Members

    public int CompareTo(object obj)
    {
      Employee emp = (Employee)obj;
      if ((emp.GammaID == this.GammaID) &&
          (emp.Barcode == this.Barcode))
      {
        return 0;
      }
      return -1;
    }

    #endregion
  }
}
