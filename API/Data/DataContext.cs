using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Configurations;
using API.Data;
using API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.Data
{
    public class DataContext
    {

        public DataContext(IOptions<DatabaseSettings> dbSettings)
        {
            var client = new MongoClient(dbSettings.Value.ConnectionString);

            var database = client.GetDatabase(dbSettings.Value.DatabaseName);

            Drivers = database.GetCollection<Driver>(dbSettings.Value.CollectionName);

            DataContextSeed.SeedData(Drivers);
        }

        public IMongoCollection<Driver> Drivers { get; }
    }
}