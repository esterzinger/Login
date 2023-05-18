using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        EsterChaniContext _EsterChaniContext;

        public RatingRepository(EsterChaniContext esterChaniContext)
        {
            _EsterChaniContext = esterChaniContext;
        }

        public async Task<Rating> CreatRating(Rating rating)
        {
            await _EsterChaniContext.Rating.AddAsync(rating);
            await _EsterChaniContext.SaveChangesAsync();

            return rating;

        }

    }
}
