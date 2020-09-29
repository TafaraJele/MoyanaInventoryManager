using _365Solutions.Shared.Contracts;
using _365Solutions.Shared.Contracts.Enums;
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
    public class OrderReportRepository : IOrderReport
    {
        private readonly MongoContext _context;

        public OrderReportRepository()
        {
            _context = new MongoContext();
        }

        public Task<IEnumerable<OrderRecord>> FindAggregatesAsync(List<SearchParameter> searchParameters, FilterType filterType)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderRecord> LoadAggregateAsync(Guid id)
        {
            var filter = Builders<OrderRecord>.Filter.Eq("_id", id);
            if(filter == null)
            {
                throw new ArgumentException("Invalid child search parameters specified");
            }
            var result = (await _context.OrderRecords.FindAsync(filter)).FirstOrDefault();
            return result ?? EntityFactory.CreateOrderRecord(id);
        }

        public async Task<Guid> SaveAggregateAsync(OrderRecord aggregate)
        {
            FilterDefinition<OrderRecord> filter = Builders<OrderRecord>.Filter.Eq("_id", aggregate.Id);
            var result = await _context.OrderRecords.FindAsync(filter);
            if (result.Any())
            {
                await _context.OrderRecords.ReplaceOneAsync(filter, aggregate);
            }
            else
            {
                await _context.OrderRecords.InsertOneAsync(aggregate);
            }

            return aggregate.Id;
        }
    }
}
