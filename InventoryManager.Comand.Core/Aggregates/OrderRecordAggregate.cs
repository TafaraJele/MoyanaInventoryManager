using _365Solutions.Shared.Contracts;
using InventoryManager.Model.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Aggregates
{
  public  class OrderRecordAggregate :  BaseAggregate<Entities.OrderRecord>
    {
        ValidationResult validationResult = new ValidationResult();
        
        public OrderRecordAggregate(Entities.OrderRecord entity) : base(entity)
        {

        }
        private ValidationResult ValidateCustomer(Model.Command.OrderCommand order)
        {
            if (string.IsNullOrEmpty(order.CustomerName))
            {
                validationResult.AddValidationMessage(_365Solutions.Shared.Contracts.Enums.ResultMessageType.Error, "Name", "Customer name is required");
            }
            return validationResult;
        }

        private ValidationResult ValidateOrderId(Model.Command.OrderCommand order)
        {
            if (string.IsNullOrEmpty(Convert.ToString(order.OrderID)))
            {
                validationResult.AddValidationMessage(_365Solutions.Shared.Contracts.Enums.ResultMessageType.Error, "ID", "OrderId is required");
            }
            return validationResult;
        }
        private ValidationResult ValidateProductName(Model.Command.OrderCommand order)
        {
            if (string.IsNullOrEmpty(Convert.ToString(order.ProductName)))
            {
                validationResult.AddValidationMessage(_365Solutions.Shared.Contracts.Enums.ResultMessageType.Error, "ProductName", "ProductName is required");
            }
            return validationResult;
        }
        private ValidationResult ValidateProductQuantity(Model.Command.OrderCommand order)
        {
            if (string.IsNullOrEmpty(Convert.ToString(order.OrderQuantity)))
            {
                validationResult.AddValidationMessage(_365Solutions.Shared.Contracts.Enums.ResultMessageType.Error, "ProductAmuont", "ProductAmount is required");
            }
            return validationResult;
        }

        public void SetOrderDetails(Model.Command.OrderCommand order)
        {
            Entity.CustomerName = order.CustomerName;
            Entity.Id = order.OrderID;
            Entity.OrderQuantity = order.OrderQuantity;
            Entity.ProductName = order.ProductName;
        }

        public ValidationResult Register(Model.Command.OrderCommand oder)
        {
            if (ValidateCustomer(oder).IsValid && ValidateProductName(oder).IsValid && ValidateOrderId(oder).IsValid && ValidateProductQuantity(oder).IsValid ) 
            {
                //   _isNew = true;
                SetOrderDetails(oder);
                AddEvent(new OderAdded(Entity.OrderQuantity, Entity.CustomerName, Entity.ProductName, Entity.Id));
                return validationResult;
            }


            return validationResult;
        }
        public void Remove()
        {
            Entity.SetAsDeleted();
            AddEvent(new OderRemoved(Entity.Id, Entity.isDeleted));
        }
    }
}
