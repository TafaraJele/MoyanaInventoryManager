using _365Solutions.Shared.Messaging;
using InventoryManager.Comand.Core;
using InventoryManager.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Model.Events
{
   public class CustomerRecordAdded : IEvent

    {
        public CustomerRecordAdded(Guid orderId, Guid recordId)
        {
            this.EventId = Guid.NewGuid();
            this.EventTime = DateTime.UtcNow;
            this.OrderId = orderId;
            Id = recordId;

        }
       
        public Guid Id { get; set; }
        public Guid EventId { get; }
        public Guid OrderId { get; }

        public DateTime EventTime { get; }

        public _365Solutions.Shared.Messaging.IEventData EventData { get; set; }

        string IMessage.Name => "CustomerRecordAdded".ToLower();

        public string Name = "CustomerRecordAdded".ToLower();

    }
}
