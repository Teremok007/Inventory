using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public class Scan
  {
    public int ArtCode { get; set; }
    public int Qty { get; set; }
    public int GammaID { get; set; }
    public DateTime Dt { get; set; }

    public Scan(int artcode,  int gammaid, int qty)
    {
      this.ArtCode = artcode;
      this.Qty = qty;
      this.GammaID = gammaid;
      this.Dt = DateTime.Now;
    }
    public Scan(int artcode,int gammaid): this(artcode, gammaid, 0)
    { }
  }
}
