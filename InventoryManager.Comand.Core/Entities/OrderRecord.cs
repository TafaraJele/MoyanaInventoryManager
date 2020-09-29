using InventoryManager.Comand.Core.Entiti;
using InventoryManager.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Entities
{
    public class OrderRecord : BaseEntity, IAggregateRoot
    {
        public DateTime LastProcessedEventTime => DateTime.UtcNow;
        public Guid OderID;
        public string CustomerName { get; set; }
        public string  ProductName { get; set; }
        public int OrderQuantity { get; set; }

        public OrderRecord(Guid oderID)
        {
            OderID = oderID;
        }

        public OrderRecord()
        {
        }
    }
}
