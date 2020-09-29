using _365Solutions.Shared.Contracts;
using InventoryManager.Model.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Query.Handlers.Services
{
    public interface IInventoryReadsHandler
    {
        Task<IEnumerable<CustomerRecordQuery>> GetCustomerRecords(RequestContext requestContext);
    }
}
