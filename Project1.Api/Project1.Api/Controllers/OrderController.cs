using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Project1.DB;
using Project1.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        


        private readonly IDBCommands dBCommands;
        private readonly ILogger<OrderController> logger;
        public OrderController(IDBCommands dBCommands, ILogger<OrderController> logger)
        {
            this.dBCommands = dBCommands;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> listOrderDetailsOfCustomerAsync([FromQuery, Required] int customer)
        {

            IEnumerable<Order> orders;

            try
            {
                orders = await dBCommands.listOrderDetailsOfCustomerAsync(customer);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "SQL error while getting rounds of customer ID {customer}", customer);
                return StatusCode(500);
            }

            return orders.ToList();
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}



