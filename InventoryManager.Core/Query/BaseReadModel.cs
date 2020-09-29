using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventoryManager.Model.Query
{
    [DataContract]
  public  class BaseReadModel : IQueryModel
    {
        private Guid _id;
        protected bool _isDeleted;

        public BaseReadModel(Guid id, bool isDeleted)
        {
            if(Equals(id, default(Guid)))
            {
                throw new ArgumentException("The ID cant be the default value.", "id");
            }
            _id = id;
            _isDeleted = isDeleted;
        }

        public BaseReadModel()
        {
        }

        [DataMember(Name = "id")]
      

        public Guid Id
        {
            get { return this._id; }
            set { _id = value; }
        }

        public bool IsDeleted
        {
            get { return this._isDeleted; }
            set { _isDeleted = value; }
        }
        public void SetAsDeleted()
        {
            _isDeleted = true;
        }

    }
}
