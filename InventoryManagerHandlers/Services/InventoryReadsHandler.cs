using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using _365Solutions.Shared.Contracts;
using InventoryManager.Model.Query;
using InventoryManager.Query.Handlers.Data;

namespace InventoryManager.Query.Handlers.Services
{
    public class InventoryReadsHandler : IInventoryReadsHandler
    {
        private ICustomerRecordsRepository _customerRecordsRepository;

        public InventoryReadsHandler(ICustomerRecordsRepository customerRecordsRepository)
        {
            _customerRecordsRepository = customerRecordsRepository;
        }

        public async Task<IEnumerable<CustomerRecordQuery>> GetCustomerRecords(RequestContext requestContext)
        {
            return await _customerRecordsRepository.FindModelAsync(new List<SearchParameter> { });
        }
    }
}
