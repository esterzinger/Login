using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entity;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await _CategoryService.GetAllCategories();
        }

       
        // POST api/<OrderController>
        [HttpPost]
        public async Task<Category> Post([FromBody] Category category)
        {
            return (await _CategoryService.CreatCategory(category));

        }

        
    }
}
