using InventoryManager.Comand.Core.Entities;
using InventoryManager.Comand.Core.Repositories.Write;
using InventoryManager.Model.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Repositories
{
   public interface ICustomerRecordRepository : IReadRepository<CustomerRecordQuery, Guid >
    {
    }
}
