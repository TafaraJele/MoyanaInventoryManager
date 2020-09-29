using _365Solutions.Shared.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Aggregates
{
    public abstract class BaseAggregate<T> : IAggregate<T> where T : IAggregateRoot
    {
          private readonly IDictionary<Type, IEvent> _events = new Dictionary<Type, IEvent>();
        protected T _entity;

        public IEnumerable<IEvent> Events => _events.Values;

        public BaseAggregate(T entity)
        {
            _entity = entity;
        }
        public T Entity => _entity;
        public Guid Id => Entity.Id;

        //IEnumerable<IEvent> IAggregate<T>.Events => _events;

        public void AddEvent(IEvent @event)
        {
            _events[@event.GetType()] = @event;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearEvents()
        {
            _events.Clear();
        }

       
    }
}
