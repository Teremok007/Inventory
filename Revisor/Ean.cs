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

      public override string ToString() 
      {
        if (view == null)
        {
          return string.Format(@"Ean\{ ArtCode={0}; Ean13={1}; Name={2}; Koef={3}; ControlQty={4}; Nds={5}; Manufacturer={6}\}", 
                  this.ArtCode, 
                  this.Ean13, 
                  this.Name, 
                  this.Koef,
                  this.ControlQty,
                  this.Nds,
                  this.Manufacturer);
        }
        return view(this);
      }
    }
}
