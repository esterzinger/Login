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
    public class ProductController : ControllerBase
    {
        IProductService _IProductService;
        IMapper _mapper;
        public ProductController(IProductService _productService, IMapper mapper)
        {
            _IProductService = _productService;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]

        public async Task<List<ProductDto>> Get([FromQuery]  int?[] categories,[FromQuery] string? name, [FromQuery]  int? minprice,[FromQuery]  int? maxprice,[FromQuery]  string? description)
        {
            List<Product> products = await _IProductService.GetAllProduct(categories, name, minprice, maxprice, description);
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            return productsDto;
            
        }

        // GET api/<ProductController>/5
       // [HttpGet("{id}")]
       // public string Get(int id)
       // {
       //     return "value";
       // }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post([FromBody] ProductDto productDto)
        {
           Product product= _mapper.Map<ProductDto, Product>(productDto);
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
