using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public class DbInfo
  {
    public string Version { get; set; }
    public string AptekaID { get; set; }
    public string AptekaName { get; set; }
    public string PereuchetDateText { get; set; }
    public DateTime PereuchetDate { get; set; }
    public string SprEanRowCountText { get; set; }
    public string PereuchetRowCountText { get; set; }
  }
}
