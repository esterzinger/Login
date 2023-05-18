using Entity;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreatProduct(Product product);
        Task<List<Product>> GetAll(int?[] categories, string? name, int? minprice, int? maxprice, string? description);
        Task<Product> GetProductById(int id);
    }
}