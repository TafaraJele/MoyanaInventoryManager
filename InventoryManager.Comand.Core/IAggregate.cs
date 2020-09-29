using _365Solutions.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core
{
  public  interface IAggregate<T>  where T : IAggregateRoot
    {

       
        /// <summary>
        /// The root entity which will persist the data
        /// </summary>
        T Entity { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IEvent> Events { get; }

        /// <summary>
        /// Adds an event to the event collection
        /// </summary>
        /// <param name="domainEvent"></param>
        void AddEvent(IEvent domainEvent);

        /// <summary>
        /// Removes all events from the event collection
        /// </summary>
        void ClearEvents();
    }
}

