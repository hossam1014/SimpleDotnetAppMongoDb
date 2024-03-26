using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using MongoDB.Driver;

namespace API.Data
{
    public class DataContextSeed
    {
        public static void SeedData(IMongoCollection<Driver> DriverCollection)
        {
            bool existDriver = DriverCollection.Find(x => true).Any();

            if (!existDriver)
            {
                DriverCollection.InsertManyAsync(GetPreconfiguredDriver());
            }
        }

        private static IEnumerable<Driver> GetPreconfiguredDriver()
        {
            return new List<Driver>()
            {
                new Driver()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    DriverName = "hossam mostafa",
                    Number = 44,
                    Team = "Mercedes",
                    
                },
                new Driver()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    DriverName = "ahmed alsayed",
                    Number = 56,
                    Team = "Mercedes",
                    
                },
            };
        }
    }
}