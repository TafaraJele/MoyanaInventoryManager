using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventoryManager.Model.Query
{
    [DataContract]
   public class CustomerRecordQuery : BaseReadModel
    {
        public CustomerRecordQuery(Guid id)
        {
            Id = id;
        }

        [DataMember(Name = "orderId")]
        public Guid OrderId { get; set; }


    }
}
