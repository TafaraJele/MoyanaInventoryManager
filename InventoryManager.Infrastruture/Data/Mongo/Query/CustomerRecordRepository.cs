using _365Solutions.Shared.Contracts;
using InventoryManager.Comand.Core.Repositories;
using InventoryManager.Model.Query;
using InventoryManager.Query.Handlers.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Infrastruture.Data.Mongo.Query
{
    public class CustomerRecordRepository : ICustomerRecordsRepository 

    {
        private readonly MongoContext _mongoContext;

        public CustomerRecordRepository()
        {
           _mongoContext = new MongoContext();
        }


        public async Task<IEnumerable<CustomerRecordQuery>> FindModelAsync(List<SearchParameter> searchParameters)
        {
            try {

                FilterDefinition<CustomerRecordQuery> filter = Builders<CustomerRecordQuery>.Filter.Ne("isDeleted", true);
                IAsyncCursor<CustomerRecordQuery> result = await _mongoContext.CustromerRecordsQuery.FindAsync(filter);
                return result.ToList();
            } catch (Exception ex)
            {

            }
            return new List<CustomerRecordQuery>();
        }

        public Task<CustomerRecordQuery> LoadModelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> SaveModelAsync(CustomerRecordQuery model)
        {
            await _mongoContext.CustromerRecordsQuery.InsertOneAsync(model);
            return model.Id;
        }

        //public Task<Guid> SaveModelAsync(CustomerRecordQuery model)
        //{
        //    throw new NotImplementedException();
        //}

       
    }
}
