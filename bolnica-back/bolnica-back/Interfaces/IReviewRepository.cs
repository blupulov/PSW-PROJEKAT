using bolnica_back.Model;

namespace bolnica_back.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        public void CancleReview(long id);
        public void AddReviewRating(ReviewRating rating);
    }
}
