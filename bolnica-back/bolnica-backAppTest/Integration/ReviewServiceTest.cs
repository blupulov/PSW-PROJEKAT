using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Repositories;
using bolnica_back.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bolnica_backAppTest.Integration
{
    public class ReviewServiceTest
    {

        [Fact]
        public void Get_by_id()
        {
            ReviewService reviewService = CreateReviewService();

            Review review = reviewService.FindReviewById(1);

            Assert.NotNull(review);
        }

        [Fact]
        public void Get_all_past_reviews_of_doctor()
        {
            ReviewService reviewService = CreateReviewService();

            List<ReviewDTO> reviews = reviewService.GetAllPastReviewsOfDoctor(2);

            Assert.NotNull(reviews);
        }

        [Fact]
        public void Get_all_past_reviews_of_patient()
        {
            ReviewService reviewService = CreateReviewService();

            List<ReviewDTO> reviews = reviewService.GetAllPastReviewsOfPatient(2);

            Assert.NotNull(reviews);
        }

        [Fact]
        public void Get_all_next_reviews_of_doctor()
        {
            ReviewService reviewService = CreateReviewService();

            List<ReviewDTO> reviews = reviewService.GetAllNextReviewsOfDoctor(2);

            Assert.Empty(reviews);
        }

        [Fact]
        public void Get_all_next_reviews_of_patient()
        {
            ReviewService reviewService = CreateReviewService();

            List<ReviewDTO> reviews = reviewService.GetAllNextReviewsOfPatient(2);

            Assert.Empty(reviews);
        }



        private ReviewService CreateReviewService()
        {
            IReviewRepository repo = new ReviewRepository(new ApplicationDbContext());
            return new ReviewService(repo, CreateDoctorService(), CreateUserService(), CreateReviewRatingService(), CreatePenaltyPointService());
        }

        private ReviewRatingService CreateReviewRatingService()
        {
            IReviewRatingRepository repo = new ReviewRatingRepository(new ApplicationDbContext());

            return new ReviewRatingService(repo);
        }

        private DoctorService CreateDoctorService()
        {
            IDoctorRepository repo = new DoctorRepository(new ApplicationDbContext());

            return new DoctorService(repo);

        }
        private UserService CreateUserService()
        {
            IUserRepository repo = new UserRepository(new ApplicationDbContext());
            return new UserService(repo, CreatePenaltyPointService());
        }

        private PenaltyPointService CreatePenaltyPointService()
        {
            IPenaltyPointRepository repo = new PenaltyPointRepository(new ApplicationDbContext());
            return new PenaltyPointService(repo);
        }
    }
}
