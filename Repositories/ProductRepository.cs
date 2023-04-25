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
        public async Task<List<Product>> GetAll(int?[] categories, int? minprice, int? maxprice, string? description)
        {
            Console.WriteLine(categories + "ffffffffffffffffffffffffffffff");
            //return new string[] { "value1", "value2" };
            
                var query=_EsterChaniContext.Products.Where(Product=> 
                (minprice==null || Product.Price <= minprice)&&
                  (maxprice==null || Product.Price >= maxprice)&&
                   (categories.Length==0 || categories.Contains(Product.CategoryId))&&
                    (description==null || Product.Description.Contains(description))
                );
            return await query.ToListAsync();
        }
        public async Task<Product> CreatProduct(Product product)
        {
            await _EsterChaniContext.Products.AddAsync(product);
            await _EsterChaniContext.SaveChangesAsync();

            return product;

        }
    }
}
