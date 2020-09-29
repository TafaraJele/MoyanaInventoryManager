using _365Solutions.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Comand.Core
{
 public   interface IEventDispatcher
    {
        Task DispatchAsync<T>(params T[] events) where T : IEvent; 
    }
}
