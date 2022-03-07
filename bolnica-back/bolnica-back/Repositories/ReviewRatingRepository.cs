using bolnica_back.Interfaces;
using bolnica_back.Model;

namespace bolnica_back.Repositories
{
    public class ReviewRatingRepository : Repository<ReviewRating>, IReviewRatingRepository
    {
        public ReviewRatingRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
