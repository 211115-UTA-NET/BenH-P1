using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.Data.SqlClient;
using Project1.DB;
using Project1.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDBCommands dBCommands;
        private readonly ILogger<LocationController> logger;
        public LocationController(IDBCommands dBCommands, ILogger<LocationController> logger)
        {
            this.dBCommands = dBCommands;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> listOrderDetailsOfLocationAsync([FromQuery, Required] string locationID)
        {

            IEnumerable<Order> orders;

            try
            {
                orders = await dBCommands.listOrderDetailsOfLocationAsync(locationID);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "SQL error while getting orders of location ID {locationID}", locationID);
                return StatusCode(500);
            }

            return new JsonResult(orders);
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
