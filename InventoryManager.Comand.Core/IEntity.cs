using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core
{
    public interface IEntity
    {
        Guid Id {get; set;}
        bool isDeleted { get; set; }
    }
}
