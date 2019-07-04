using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
    public delegate string StringView(Ean ean);
    public class Ean
    {
      
      private string ean13;
      public StringView view;
//      public string Key { get; set; }
      public int ArtCode { get; set; }
      public string Ean13 { get { return ean13; } set { ean13 = value.PadLeft(13); } }
      public string Name { get; set; }
      public int Koef { get; set; }
      public int ControlQty { get; set; }
      public int Nds { get; set; }
      public string Manufacturer { get; set; }

      public string ToString() 
      {
        if (view == null)
        {
          return string.Format("{0}\t{1}\t{2}\t{3}", this.ArtCode, this.Ean13, this.Name);
        }
        return view(this);
      }
    }
}
