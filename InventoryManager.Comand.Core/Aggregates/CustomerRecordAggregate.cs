using _365Solutions.Shared.Contracts;
using _365Solutions.Shared.Contracts.Enums;
using InventoryManager.Model.Command;
using InventoryManager.Model.Events;
using InventoryManager.Model.Shared;
using System;
using System.Collections.Generic;
using System.Text;



namespace InventoryManager.Comand.Core.Aggregates
{
   public  class CustomerRecordAggregate : BaseAggregate<Entities.CustomerRecord>
    {
        public bool _isNew;
        ValidationResult validationResult = new ValidationResult();

        Customer _Customer = new Customer() {
            CustomerName = "Nick Fury",
            CustomerAddress = "C137"
        };
        
        
        public CustomerRecordAggregate(Entities.CustomerRecord entity) : base (entity)
        {
        }

        public ValidationResult CreateCustomerRecord(Order oder)
        {
            _isNew = true;
            if (ValidateOrderId(oder.OrderID).IsValid)
            {
                Entity.AddOrder(oder);
                return validationResult;
            }
            return validationResult;
        }

        public ValidationResult CreateOder(Model.Command.CustomerRecord customerRecord)
        {
            //put registration logic
            if (ValidateOrderId(customerRecord.OrderID).IsValid)
            {
                Entity.AddCustomerRecord(customerRecord);

                AddEvent(new CustomerRecordAdded(customerRecord.OrderID, new Guid()));
                return validationResult;
            }
           
            return validationResult;
        }

        public ValidationResult ValidateOrderId(Guid OrderId)
        {
            if (Guid.Empty == OrderId)
            {
                validationResult.AddValidationMessage(ResultMessageType.Error, "OrderId", "Order id is required");
            }

            return validationResult;
        }

    }
}
