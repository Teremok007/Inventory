using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public delegate void ItemStateHandler(string Message);

  public class OrderItem 
  {

    public Scan Scan {get; set;}
    public ScanLog ScanLog{get; set; }
    public Guid Id { get; set; }
    public Guid HeadId { get; set; }
    public DateTime DateCreated { get; set; }
    public String Name { get { return Ean.Name; } }
    public int ArtCode { get { return Ean.ArtCode; } }
    public int Qty
    {
      get
      {
        return Scan.Qty;
      } 
      set
      {
        Scan.Qty = value;
        ScanLog.Qty = value;
        if ((AddedMore != null) && (Scan.Qty > this.Ean.ControlQty) && GlobalArea.AppOption.IsMoreQtyMessage)
          AddedMore("Количество больше расчетного.");
      }
    }
    public Ean Ean { get; set; }
    
    public OrderItem(Ean ean, Scan scan)
    {
      this.Ean = ean;
      this.Scan = scan;
      this.Id = Guid.NewGuid();
      this.DateCreated = DateTime.Now;
      this.ScanLog = new ScanLog(ean.ArtCode,
                                 GlobalArea.CurrentEmployee.GammaID,
                                 scan.Qty,
                                 GlobalArea.CurrentDateSQLStr, 
                                 ean.Ean13);
    }

    public OrderItem AddOne()
    {
      this.Qty += Ean.Koef;
      return this;
    }

    public OrderItem Inc(int aQty)
    {
      this.Qty += aQty;
      return this;
    }
    public event ItemStateHandler AddedMore;
    
  }
}
