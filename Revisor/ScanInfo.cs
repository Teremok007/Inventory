using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public class ScanInfo
  {
    public int Count { get; set; }
    public int SumQty { get; set; }

    public override string ToString()
    {
      return string.Format(@"ScanInfo\{Count={0}; Su,Qty={1}\}", this.Count.ToString(), this.SumQty.ToString());
    }
  }
}
