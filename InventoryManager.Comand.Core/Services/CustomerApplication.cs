using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _365Solutions.Shared.Contracts;
using _365Solutions.Shared.Contracts.Enums;
using InventoryManager.Comand.Core;
using InventoryManager.Comand.Core.Aggregates;
using InventoryManager.Model.Command;
using InventoryManager.Comand.Core.Repositories.Write;


namespace InventoryManager.Comand.Core.Services
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IEventDispatcher _eventDispatcher;
        private CommandResult commandResult;
        private ICustomerReport _customerReport;
        private readonly IOrderReport _oderReport;
       // Guid id = Guid.NewGuid();

        public CustomerApplication(IEventDispatcher eventDispatcher, ICustomerReport customerReport, IOrderReport oderReport)
        {
            _eventDispatcher = eventDispatcher;
            _customerReport = customerReport;
            _oderReport = oderReport;
        }

        public async Task<CommandResult> CreateOder(CustomerRecord customerRecord)
        {
            var entity = await _customerReport.LoadAggregateAsync(Guid.Empty);
            CustomerRecordAggregate aggregate = new CustomerRecordAggregate(entity);

            aggregate.CreateOder(customerRecord);
            await _customerReport.SaveAggregateAsync(aggregate.Entity);
            await PublishAggregateEvents(aggregate);
            commandResult = new CommandResult(customerRecord.OrderID, true);
            return commandResult;
            
        }

        public async Task<CommandResult> CreateProductOrder(OrderCommand orderCommand)
        {
            var entity = await _oderReport.LoadAggregateAsync(Guid.Empty);
            OrderRecordAggregate orderaggreagate = new OrderRecordAggregate(entity);

            orderaggreagate.Register(orderCommand);
            await _oderReport.SaveAggregateAsync(orderaggreagate.Entity);
            await PublishAggregateEvents(orderaggreagate);
            commandResult = new CommandResult(orderCommand.OrderID, true);
            return commandResult;
        }


        private async Task PublishAggregateEvents<T>(IAggregate<T> aggregate) where T : IAggregateRoot
        {

            if (aggregate.Events != null && aggregate.Events.Any())
            {
                await _eventDispatcher.DispatchAsync(aggregate.Events.ToArray());
                aggregate.ClearEvents();
            }
        }

        public async Task<CommandResult> UpdateOrder(Guid id, OrderCommand orderCommand)
        {
            var entity = await _oderReport.LoadAggregateAsync(id);
            OrderRecordAggregate orderaggreagate = new OrderRecordAggregate(entity);

            orderaggreagate.Register(orderCommand);
            await _oderReport.SaveAggregateAsync(orderaggreagate.Entity);
            await PublishAggregateEvents(orderaggreagate);
            commandResult = new CommandResult(orderCommand.OrderID, true);
            return commandResult;
        }

        public async Task<CommandResult> RemoveProductOrder(Guid id)
        {
            var entity = await _oderReport.LoadAggregateAsync(id);
            OrderRecordAggregate orderaggreagate = new OrderRecordAggregate(entity);

            orderaggreagate.Remove();
            await _oderReport.SaveAggregateAsync(orderaggreagate.Entity);
            await PublishAggregateEvents(orderaggreagate);
            commandResult = new CommandResult(orderaggreagate.Id, true);
            return commandResult;
        }
    }
}
