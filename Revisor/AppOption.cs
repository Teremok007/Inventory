using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  enum MultipleQty { BY_PIECE = 0,  BY_PACKAGE = 1 }
  
  delegate void AppOptionEventHandler(AppOption appOption);
  
  class AppOption
  {
    private bool fastScan;
    public bool FastScan { get { return fastScan; } set { if (fastScan != value) { fastScan = value; OnAppOptionChanged(this); } } }

    private bool isMoreQtyMessage;
    public bool IsMoreQtyMessage { get { return isMoreQtyMessage; } set { if (isMoreQtyMessage != value) { isMoreQtyMessage = value; OnAppOptionChanged(this); } } }

    private MultipleQty mulQtyType;
    public MultipleQty MultypleQtyType { get { return mulQtyType; } set { if (mulQtyType != value) { mulQtyType = value; OnAppOptionChanged(this); } } }

    public AppOption()
    {
      this.FastScan = false;
      this.IsMoreQtyMessage = false;
      this.MultypleQtyType = MultipleQty.BY_PACKAGE;
    }

    protected virtual void OnAppOptionChanged(AppOption appOption)
    {
      AppOptionEventHandler oCahnged = AppOptionChanged;
      if (oCahnged != null)
      {
        oCahnged(this);
      }
    }
    public event AppOptionEventHandler AppOptionChanged;
  }
}
