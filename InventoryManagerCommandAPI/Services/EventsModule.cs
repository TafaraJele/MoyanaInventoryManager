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
    public class EventsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventDispatcher>()
                .As<IEventDispatcher>()
                .InstancePerLifetimeScope();
            var assembly = Assembly.Load(new AssemblyName("InventoryManager.Comand.Core"));
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandler<>));
        }
    }
    public static class Container
    {
        public static IContainer Resolve()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<EventsModule>();

            return builder.Build();
        }
    }
}
