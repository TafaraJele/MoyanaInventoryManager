using InventoryManager.Comand.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Infrastruture.Data.Mongo.Write
{
   public class MongoContext 
    {
        MongoClient dbClient;
        IMongoDatabase database { get; }

        public MongoContext()
        {
            dbClient = new MongoClient("mongodb://localhost");
            database = dbClient.GetDatabase("InventoryManagerWrite");
        }

        public IMongoCollection<CustomerRecord> CustromerRecords => database.GetCollection<CustomerRecord>("CustomerRecords");
        public IMongoCollection<OrderRecord> OrderRecords => database.GetCollection<OrderRecord>("OrderRecords");
    }
}
