using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventoryManager.Model.Command
{
    [DataContract]
  public  class CustomerRecord
    {
        [DataMember(Name = "OderID")]
        public Guid OrderID { get; set; }
    }
}
