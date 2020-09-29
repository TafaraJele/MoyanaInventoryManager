using _365Solutions.Shared.Contracts;
using _365Solutions.Shared.Contracts.Enums;
using InventoryManager.Comand.Core.Aggregates;
using InventoryManager.Comand.Core.Entities;
using InventoryManager.Comand.Core.Repositories.Write;
using InventoryManager.Comand.Core.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Infrastruture.Data.Mongo.Write
{
    public class CustomerReportRepository : ICustomerReport
    {
        private MongoContext _context;

        public CustomerReportRepository()
        {
            _context = new MongoContext();
        }

        public Task<IEnumerable<CustomerRecord>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerRecord> LoadAggregateAsync(Guid id)
        {
            var filter = Builders<CustomerRecord>.Filter.Eq("_id", id);
            if (filter == null)
            {
                throw new ArgumentException("Invalid search parameters specified");
            }

            var result = (await _context.CustromerRecords.FindAsync(filter)).FirstOrDefault();

            return result ?? EntityFactory.CreateCustomerRecord(Guid.NewGuid());
           


        }
        public async Task<Guid> SaveAggregateAsync(CustomerRecord aggregate)
        {
            FilterDefinition<CustomerRecord> filter = Builders<CustomerRecord>.Filter.Eq("_id", aggregate.Id);

            var result = await _context.CustromerRecords.FindAsync(filter);
            if (result.Any())
            {
                await _context.CustromerRecords.ReplaceOneAsync(filter, aggregate);
            }
            else
            {
                await _context.CustromerRecords.InsertOneAsync(aggregate);
            }
            return aggregate.Id;
        }


    }

    }
