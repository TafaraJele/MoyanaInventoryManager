using InventoryManager.Comand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Services
{
    public class EntityFactory
    {
        public static CustomerRecord CreateCustomerRecord(Guid id)
        {
            return new CustomerRecord(id)
            {
                Id = id, 
            };
        }
        public static OrderRecord CreateOrderRecord(Guid _OrderID)
        {
            return new OrderRecord(_OrderID)
            {
                OderID = _OrderID

        };
        }
    }
}
