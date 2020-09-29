using _365Solutions.Shared.Contracts;
using _365Solutions.Shared.Messaging;
using InventoryManager.Comand.Core.Repositories;
using InventoryManager.Model.Events;
using InventoryManager.Model.Query;
using InventoryManager.Query.Handlers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Comand.Core.EventHandlers.CustomerRecord
{
    public class CustomerRecordAddedEventHandler : IEventHandler<CustomerRecordAdded>
    {
        private ICustomerRecordsRepository _recordRepository;

        public CustomerRecordAddedEventHandler(ICustomerRecordsRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }


        public string HandlerName => "CustomerRecordAddedEventHandler".ToLower();
    public async Task<List<CustomerRecordQuery>> FindAggregate(Guid OrderId)
        {
            List<SearchParameter> parameters = new List<SearchParameter>()
            {
                new SearchParameter(){Name = "ORDERID", Value = OrderId.ToString()}

            };
            var records = await _recordRepository.FindModelAsync(parameters);
            return records.ToList();
        }

        public async Task HandleAsync(CustomerRecordAdded @event)
        {
            CustomerRecordQuery customerRecord = new CustomerRecordQuery(@event.OrderId);
            var customerRecords = await FindAggregate(@event.OrderId);
            if(customerRecords != null)
            {
                customerRecord = customerRecords.FirstOrDefault();
            }
            if(customerRecord == null)
            {
                customerRecord = new CustomerRecordQuery(@event.OrderId);
            }
            await _recordRepository.SaveModelAsync(customerRecord);
        }
    }
}
