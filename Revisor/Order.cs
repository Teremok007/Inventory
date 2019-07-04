using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BarcodeFramework
{
  [Serializable]
  public class Order
  {
    //private DataSet mapDataSet;
    //private DataRow mapDataRow;

    //public OrderItemList OSpec;

    //public Guid Id { get { return (Guid)mapDataRow["OHeadGUID"]; } set { mapDataRow["OHeadGUID"] = value; } }
    //public string Num { get { return mapDataRow["Num"].ToString(); } set { mapDataRow["Num"] = value; } }
    //public DateTime CreatedDate { get { return (DateTime)mapDataRow["CreatedDate"]; } set { mapDataRow["CreatedDate"] = value; } }
    //public int Status { get { return (int)mapDataRow["Status"]; } set { mapDataRow["Status"] = value; } }

    //public DataSet MappedDataSet { get {return mapDataSet;} }
    //public DataRow MappedDataRow { get { return mapDataRow; } }

    public Dictionary<string, OrderItem> OSpec;
    private Guid id;
    public Guid Id { get { return id; } set{} }
    public int Count { get { return OSpec.Count; } }
//    public string Num { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Status { get; set; }
    
    public Order()
    {
      id = Guid.NewGuid();
      OSpec = new Dictionary<string, OrderItem>();
    }

    public bool IsExistsItem(string ean, int artcode)
    {
      return (GetItemByArtCode(ean, artcode) != null);
    }

    public OrderItem GetItemByEan(string ean)
    {
      if (!OSpec.ContainsKey(ean))
      {
        return null;
      }
      return OSpec[ean];
    }

    public OrderItem GetItemByArtCode(string ean, int artcode)
    {
      foreach (var item in OSpec.Values)
      {
        if (item.Ean.ArtCode == artcode)
          return item;
      }
      return null;
    }

    //public OrderItem GetItemByArtCode(OrderItem orderItem)
    //{
    //  foreach (var item in OSpec.Values)
    //  {
    //    if (item.Ean.ArtCode == orderItem.Ean.ArtCode)
    //      return item;
    //  }
    //  return null;
    //}

    public OrderItem AddQty(ref OrderItem item, int qty)
    {
      OrderItem saveItem = GetItemByEan(item.Ean.Ean13);
      if (saveItem != null)
      {
        saveItem.Qty += qty;
        return item;
      }
      item.Qty += qty;
      item.AddedMore += MoreQtyEvent;
      this.OSpec.Add(item.Ean.Ean13, item);
      return item;
    }

    public OrderItem AddOne(ref OrderItem item)
    { 
      item.AddOne();
      if (!OSpec.ContainsValue(item))
        OSpec.Add(item.Ean.Ean13, item);
      return item;
    }


    public OrderItem AddQty(string ean, int artcode, string artName, int qty)
    {
      OrderItem item = GetItemByArtCode(ean, artcode);
      if (item != null)
      {
        item.Qty += qty;
        return item;
      }
      item = AddNewOrderItem(ean, artcode, artName, qty);
      this.OSpec.Add(ean, item);
      return item;
    }

    public OrderItem AddNewOrderItem(string ean, int artcode, string name, int qty)
    {
      throw new NotImplementedException();
    }

    public void Clear()
    {
      OSpec.Clear();
      id = Guid.NewGuid();
    }
    public event ItemStateHandler AddedMore;
    private void MoreQtyEvent(string message)
    {
      if (AddedMore != null)
        AddedMore(message);
      
    }
  }
}
