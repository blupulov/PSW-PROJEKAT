using bolnica_back.Interfaces;
using bolnica_back.Model;
using System.Collections.Generic;

namespace bolnica_back.Services
{
    public class ReviewRatingService
    {
        private readonly IReviewRatingRepository reviewRatingRepository;
        public ReviewRatingService(IReviewRatingRepository reviewRatingRepository)
        {
            this.reviewRatingRepository = reviewRatingRepository;
        }

        public List<ReviewRating> GetAll()
        {
            return (List<ReviewRating>)reviewRatingRepository.GetAll();
        }

        public ReviewRating FindByReviewId(long reviewId)
        {
            foreach (ReviewRating rr in GetAll())
                if (rr.ReviewId == reviewId)
                    return rr;
            return null;
        }
    }
}
