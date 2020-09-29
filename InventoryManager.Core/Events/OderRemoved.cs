using _365Solutions.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Model.Events
{
    public class OderRemoved : IEvent
    {
        public Guid EventId { get; }

        public DateTime EventTime { get; }

        public string Name => "OderRemoved";
        bool IsDeleted { get; }

        public Guid _orderId { get; set; }

        public OderRemoved(Guid orderId, bool isDeleted)
        {
            EventId = Guid.NewGuid();
            IsDeleted = isDeleted;
            this.EventTime = DateTime.UtcNow;
            this._orderId = orderId;
        }
    }
}
