using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Model.Shared
{
  public  class Order
    {
        public Guid OrderID { get; set; }
        public string ProductName { get; set; }
        public string  CustomerName { get; set; }
        public int OrderQuantity { get; set; }
    }
}
