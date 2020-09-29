using InventoryManager.Comand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Repositories.Write
{
  public  interface IOrderReport : IRepository<OrderRecord, Guid>
    {
    }
}
