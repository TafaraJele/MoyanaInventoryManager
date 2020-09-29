using _365Solutions.Shared.Messaging;
using Autofac;
using InventoryManager.Comand.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Inventory.Manager.Command.API.Services
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IComponentContext _context;

        public EventDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task DispatchAsync<T>(params T[] events) where T : IEvent
        {
            foreach (var @event in events)
            {
                if (@event == null)
                    throw new ArgumentNullException(nameof(@event), "Event can not be null.");

                var eventType = @event.GetType();
                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
                object handler;
                try
                { _context.TryResolve(handlerType, out handler);


                if (handler == null)
                    return;

                //GetRuntimeMethods() works with .NET Core, otherwise simply use GetMethod()
                var method = handler.GetType()
                    .GetRuntimeMethods()
                    .First(x => x.Name.Equals("HandleAsync"));
               
                    method.Invoke(handler, new object[] { @event });

                    // await (Task)((dynamic)handler).HandleAsync(@event);
                }
                catch (Exception ex)
                {

                }

            }
        }

    }
}
