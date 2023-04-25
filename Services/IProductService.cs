using Entity;

namespace Services
{
    public interface IProductService
    {
        Task<Product> CreatProduct(Product product);
        Task<List<Product>> GetAllProduct(int?[] categories, int? minprice, int? maxprice, string? description);
    }
}