using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _IProductService;

        public ProductController(IProductService _productService)
        {
            _IProductService = _productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<Product>> Get([FromBody] int[] categories)
        {
            return await _IProductService.GetAllProduct(categories);
        }

        // GET api/<ProductController>/5
       // [HttpGet("{id}")]
       // public string Get(int id)
       // {
       //     return "value";
       // }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _IProductService.CreatProduct(product);
        }

        // PUT api/<ProductController>/5
       // [HttpPut("{id}")]
       // public void Put(int id, [FromBody] string value)
       // {
       // }

        // DELETE api/<ProductController>/5
       // [HttpDelete("{id}")]
       // public void Delete(int id)
       // {
       // }
    }
}
