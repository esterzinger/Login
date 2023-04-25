using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        EsterChaniContext _EsterChaniContext;

        public ProductRepository(EsterChaniContext esterChaniContext)
        {
            _EsterChaniContext = esterChaniContext;
        }
        public async Task<List<Product>> GetAll(int[] category)
        {
            //return new string[] { "value1", "value2" };
            return (await _EsterChaniContext.Products.Include(product => product.Category).ToListAsync());

        }
        public async Task<Product> CreatProduct(Product product)
        {
            await _EsterChaniContext.Products.AddAsync(product);
            await _EsterChaniContext.SaveChangesAsync();

            return product;

        }
    }
}
