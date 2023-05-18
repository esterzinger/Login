using Entity;

namespace Services
{
    public interface IRatingService
    {
        Task<Rating> CreatRating(Rating rating);
    }
}