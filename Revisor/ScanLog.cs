using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public enum AType{ Insert = 1, Edit = 2, Update = 3 }
  
  public class ScanLog
  {
    public int ArtCode { get; set; }
    public int GammaID { get; set; }
    public string Dt { get; set; }
    public int Qty { get; set; }
    public string Barcode { get; set; }
    public AType ActType{ get; set; }
    public string ActTypeStr
    {
      get
      {
        string res = "N";
        switch (ActType)
        {
          case AType.Insert:
            res = "I";
            break;
          case AType.Edit:
            res = "E";
            break;
          case AType.Update:
            res = "U";
            break;
        }
        return res;
      }
    }

    public ScanLog(int ArtCode, int GammaID, int Qty, string Dt, string Barcode)
    {
      this.ArtCode = ArtCode;
      this.GammaID = GammaID;
      this.Qty = Qty;
      this.Dt = Dt;
      this.Barcode = Barcode;
      switch (Qty)
      {
        case 0:
          ActType = AType.Insert;
          break;
        default:
          this.ActType = AType.Update;
          break;
      }
    }
    public ScanLog(int ArtCode, int GammaID, int Qty, string Dt, string Barcode, AType actionType)
    {
      this.ArtCode = ArtCode;
      this.GammaID = GammaID;
      this.Qty = Qty;
      this.Dt = Dt;
      this.Barcode = Barcode;
      this.ActType = actionType;
    }
  }
}
