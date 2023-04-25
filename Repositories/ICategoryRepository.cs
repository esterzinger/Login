using Entity;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> getAllCategories();
        Task<Category> CreatCategory(Category category);
    }
}