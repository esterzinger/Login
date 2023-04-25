using Entity;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreatProduct(Product product);
        Task<List<Product>> GetAll(int[] category);
    }
}