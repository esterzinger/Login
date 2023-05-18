using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using DTO;


namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _CategoryService;
        IMapper _mapper;
        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            List<Category> categories= await _CategoryService.GetAllCategories();
            List<CategoryDto> categoriesDto=_mapper.Map<List<Category>,  List < CategoryDto >> (categories);
            return categoriesDto;
        }

       
        // POST api/<OrderController>
        [HttpPost]
        public async Task<CategoryDto> Post([FromBody] CategoryDto categoryDto)
        {
            Category category = _mapper.Map<CategoryDto, Category>(categoryDto);
            Category category2= await _CategoryService.CreatCategory(category);
            CategoryDto categoryDto2 = _mapper.Map<Category, CategoryDto>(category2);
            return (categoryDto2);

        }

        
    }
}
