using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        //public async Task<List<Order>> Get()
        //{
        //    return (await _OrderService.GetAllOrders());
       // }

        // GET api/<OrderController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
         //   return "value";
        //}

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post([FromBody] Order order)
        {
           return ( await _OrderService.CreatOrder(order));
            
        }

        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
