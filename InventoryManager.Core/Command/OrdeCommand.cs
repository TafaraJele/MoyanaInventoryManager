using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventoryManager.Model.Command
{
    [DataContract]
   public class OrderCommand
    {
        [DataMember(Name = "orderId") ]
        public Guid OrderID { get; set; }
      [DataMember(Name = "productName")]
        public string ProductName { get; set; }
        [DataMember(Name = "customerName")]
        public string CustomerName { get; set; }
        [DataMember(Name = "orderQuantity")]
        public int OrderQuantity { get; set; }
    }
}
