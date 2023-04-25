using Entity;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;
        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProduct( int?[] categories,  int? minprice,  int? maxprice, string? description)
        {
            return await _ProductRepository.GetAll(categories, minprice, maxprice, description);
            //UserRepository.Get();

        }
        public async Task<Product> CreatProduct(Product product)
        {
            return await _ProductRepository.CreatProduct(product);


        }
    }
}


    


