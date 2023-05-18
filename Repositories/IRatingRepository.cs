using Entity;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> CreatRating(Rating rating);
    }
}