using bolnica_back.Interfaces;
using bolnica_back.Model;

namespace bolnica_back.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {

        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ReviewRepository() { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void CancleReview(long id)
        {
            Review review = this.FindById(id);
            review.IsCanceled = true;
            ApplicationDbContext.SaveChanges();
        }

        public void AddReviewRating(ReviewRating rating)
        {
            Review review = FindById(rating.ReviewId);
            review.Rating = rating;
            ApplicationDbContext.SaveChanges();
        }

    }
}
