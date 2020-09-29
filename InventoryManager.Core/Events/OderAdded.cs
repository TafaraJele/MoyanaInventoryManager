using _365Solutions.Shared.Messaging;
using InventoryManager.Comand.Core;
using InventoryManager.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Model.Events
{
    public class OderAdded : IEvent

    {
        public OderAdded(int oderQuantity, string customerName, string productName, Guid oderID)
        {
            OderQuantity = oderQuantity;
            CustomerName = customerName;
            ProductName = productName;
            OderID = oderID;
        }

        public int OderQuantity { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public Guid OderID { get; set; }

        public Guid EventId { get; }

        public DateTime EventTime { get; }

        public _365Solutions.Shared.Messaging.IEventData EventData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => "oder.oderAdded".ToLower();
    }
}
