using InventoryManager.Model.Query;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Infrastruture.Data.Mongo.Query
{
   public class MongoContext
    {
        MongoClient dbClient;
        IMongoDatabase database { get; }

        public MongoContext()
        {
            dbClient = new MongoClient("mongodb://localhost");
            database = dbClient.GetDatabase("InventoryManagerRead");
        }

        public IMongoCollection<CustomerRecordQuery> CustromerRecordsQuery => database.GetCollection<CustomerRecordQuery>("CustomerRecords");
      //  public IMongoCollection<CustomerRecordQuery> CustromerRecords => database.GetCollection<CustomerRecordQuery>("CustomerRecords");
    }
}
