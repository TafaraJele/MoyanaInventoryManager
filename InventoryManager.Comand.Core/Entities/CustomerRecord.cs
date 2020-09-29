
using InventoryManager.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InventoryManager.Model.Command;
using InventoryManager.Comand.Core.Entiti;

namespace InventoryManager.Comand.Core.Entities
{
    public class CustomerRecord : BaseEntity, IAggregateRoot
    {
        List<Order> orders;
        List<Product> products;
        public DateTime LastProcessedEventTime => DateTime.UtcNow;
        public Guid OrderId { get; }
        public IEnumerable<Order> Orders = new List<Order>();
        public IEnumerable<Product> Products = new List<Product>();

        public CustomerRecord()
        {
        }

        public CustomerRecord(Guid orderId)
        {
            OrderId = orderId;
            orders = new List<Order>();
            products = new List<Product>();
        }
        public void AddOrder(Order _order)
        {
            var order = orders.FirstOrDefault(s => s.OrderID == _order.OrderID);
        }
        public void AddCustomerRecord(InventoryManager.Model.Command.CustomerRecord customerRecord)
        {
            var order = orders.FirstOrDefault(s => s.OrderID == customerRecord.OrderID);

        }
    }
}
