using _365Solutions.Shared.Contracts;
using InventoryManager.Comand.Core;
using InventoryManager.Model.Command;
using InventoryManager.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Comand.Core
{
   public interface ICustomerApplication
    {
        Task<CommandResult> CreateOder(CustomerRecord customerRecord);

        Task<CommandResult> RemoveProductOrder(Guid id);
        Task<CommandResult> CreateProductOrder(OrderCommand orderCommand);

        Task<CommandResult> UpdateOrder(Guid id, OrderCommand orderCommand);
 
    }
}
