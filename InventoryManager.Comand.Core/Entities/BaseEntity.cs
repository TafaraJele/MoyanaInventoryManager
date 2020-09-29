using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Comand.Core.Entiti
{
   public  class BaseEntity : IEntity
    {
        private Guid _Id;
        protected bool _Exists;

        public BaseEntity()
        {
        }

        public BaseEntity(Guid id, bool exists)
        {
            if(Equals(id, default(Guid)))
            {
                throw new ArgumentException("The ID cant be the default id value .", "id");
            }


            _Id = id;
            _Exists = exists;
        }

        public Guid Id
        {
            get { return  _Id; }
            set {  _Id = value; }
        }
        

      

        public bool isDeleted { get {return _Exists; } set { _Exists = value; } }
        public void SetAsDeleted()
        {
            this.isDeleted = true;
        }
    }
}
