using Entity;

namespace Services
{
    public interface ICategoryService
    {
        Task<Category> CreatCategory(Category category);
        Task<List<Category>> GetAllCategories();
    }
}