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
    public string StartDt { get; set; }
    public string EndDt { get; set; }

    public Scan(int artcode,  int gammaid, int qty)
    {
      this.ArtCode = artcode;
      this.Qty = qty;
      this.GammaID = gammaid;
      this.Dt = DateTime.Now;
    }
    public Scan(int artcode,int gammaid): this(artcode, gammaid, 0)
    { }

    public override string ToString()
    {
      return string.Format(@"Scan\{ ArtCode = {0}; Qty={1}; GammaId={2}; Dt={3}; StartDt={4}; EndDt={5}\}",
        this.ArtCode.ToString(), 
        this.Qty.ToString(),
        this.GammaID.ToString(),
        this.Dt.ToShortDateString(),
        this.StartDt,
        this.EndDt
        );
    }

  }
}
