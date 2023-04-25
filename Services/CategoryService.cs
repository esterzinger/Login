using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()

        {
            return await _CategoryRepository.getAllCategories();
            //UserRepository.Get();

        }
        public async Task<Category> CreatCategory(Category category)
        {
            return await _CategoryRepository.CreatCategory(category);


        }

    }
}
