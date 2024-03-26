using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using MongoDB.Driver;

namespace API.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _context;

        public DriverRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Driver>> GetDrivers() =>  await _context.Drivers.Find(x => true).ToListAsync();


        public async Task<Driver> GetDriverById(string id) => await _context.Drivers.Find(x => x.Id == id).FirstOrDefaultAsync();


        public async Task AddDriver(Driver Driver) => await _context.Drivers.InsertOneAsync(Driver);


        public async Task<bool> UpdateDriver(Driver Driver)
        {
            var result = await _context.Drivers.ReplaceOneAsync(x => x.Id == Driver.Id, Driver);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteDriver(string id)
        {

            var result = await _context.Drivers.DeleteOneAsync(x => x.Id == id);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }


        public async Task<IEnumerable<Driver>> GetDriversByTeamName(string teamName)
        {
            // FilterDefinition<Driver> filter = Builders<Driver>.Filter.Eq(x => x.Team, teamName);

            return await _context.Drivers.Find(x => x.Team == teamName).ToListAsync();
        }


        
    }
}