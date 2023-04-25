using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        EsterChaniContext _EsterChaniContext;
        public CategoryRepository(EsterChaniContext esterTziviContext)
        {
            _EsterChaniContext = esterTziviContext;
        }
        public async Task<List<Category>> getAllCategories()
        {
            return await _EsterChaniContext.Categories.ToListAsync();
        }

        public async Task<Category> CreatCategory(Category category)
        {
            await _EsterChaniContext.Categories.AddAsync(category);
            await _EsterChaniContext.SaveChangesAsync();

            return category;

            //CreatedAtAction(nameof(Get), new { id = user.Id }, user);


        }
    }
}
