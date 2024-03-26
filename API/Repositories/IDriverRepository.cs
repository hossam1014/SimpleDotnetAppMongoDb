using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetDrivers();

        Task<Driver> GetDriverById(string id);

        Task<IEnumerable<Driver>> GetDriversByTeamName(string teamName);

        Task AddDriver(Driver Driver);

        Task<bool> UpdateDriver(Driver Driver);

        Task<bool> DeleteDriver(string id);

    }
}