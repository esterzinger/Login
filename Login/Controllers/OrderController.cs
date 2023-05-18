using AutoMapper;
using DTO;
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
        IMapper _mapper;
        public OrderController(IOrderService OrderService, IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }
        // GET: api/<OrderController>
       // [HttpGet]
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
        public async Task<OrderDto> Post([FromBody] OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto,Order >(orderDto);
            OrderDto orderDtoWiteId = _mapper.Map < Order, OrderDto > (await _OrderService.CreatOrder(order));
            return (orderDtoWiteId);
            
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
