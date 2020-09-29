using InventoryManager.Model.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Query.Handlers.Data
{
   public interface ICustomerRecordsRepository : IQueryModelRepository<CustomerRecordQuery, Guid>
    {
    }
}
