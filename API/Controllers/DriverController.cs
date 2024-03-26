using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/v1/[Controller]")]
    public class DriverController : ControllerBase
    {

        private readonly IDriverRepository _repo;

        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger, IDriverRepository repo)
        {
            _logger = logger;
            _repo = repo;

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Driver>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            var Drivers =  await _repo.GetDrivers();

            return Ok(Drivers);
        }



        [HttpGet("{id:length(24)}", Name = "GetDriver")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Driver), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Driver>> GetDriverById(string id)
        {
            var Driver =  await _repo.GetDriverById(id);

            if(Driver == null) 
            {   
                _logger.LogError($"the Driver with Id {id} , not found");
                return NotFound();
            }

            return Ok(Driver);
        }


        // Action is the method Name
        [Route("[Action]/{teamName}", Name = "GetDriversByTeam")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Driver>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDriversByTeam(string teamName)
        {
            var Drivers =  await _repo.GetDriversByTeamName(teamName);

            return Ok(Drivers);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Driver), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddDriver([FromBody] Driver Driver)
        {
            await _repo.AddDriver(Driver);

            return CreatedAtRoute("GetDriver", new {id = Driver.Id}, Driver);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Driver), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDriver([FromBody] Driver Driver)
        {
            return Ok(await _repo.UpdateDriver(Driver));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteDriver")]
        [ProducesResponseType(typeof(Driver), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDriverById(string id)
        {
            return Ok(await _repo.DeleteDriver(id));
        }

    }
}