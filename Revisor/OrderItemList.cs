using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace BarcodeFramework
{
  public class OrderItemList : List<OrderItem>
  {
    private DataTable dataTable;
    private Order parent;

    public Order Parent { get { return parent; } }

    public OrderItem AddOrderItem(OrderItem item)
    {
      base.Add(item);
      dataTable.Rows.Add(item.MappedDataRow);
      return item;
    }

    public void RemoveOrderItem(OrderItem item)
    {
      item.MappedDataRow.Delete();
      base.Remove(item);
    }

    public OrderItemList(Order parent, DataTable table)
    {
      this.parent = parent;
      this.dataTable = table;

      OrderItem orderItem;
      for (int i = 0; i < this.dataTable.Rows.Count; i++)
      {
        orderItem = new OrderItem(this.dataTable.Rows[i]);
        base.Add(orderItem);
      }
    }

    public OrderItem GetOrderItemByEan(string ean13) 
    {
      foreach (OrderItem item in this)
      {
        if (item.Ean13 == ean13)
        {
          return item;
        }
      }
      return null;
    }
  }
}
