using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core
{
   public  interface IAggregateRoot : IEntity
    {
        DateTime LastProcessedEventTime { get; }
    }
}
