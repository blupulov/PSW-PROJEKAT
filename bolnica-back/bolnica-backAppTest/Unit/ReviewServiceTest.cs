using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace bolnica_backAppTest
{
    public class ReviewServiceTest
    {
        [Fact]
        public void Can_review_be_canceled_no() 
        {
            ReviewService reviewService = CreateReviewService();

            var result = reviewService.CancleReview(2000);

            Assert.True(!result);
        }

        [Fact]
        public void Can_review_be_canceled_yes()
        {
            ReviewService reviewService = CreateReviewService();

            var result = reviewService.CancleReview(2001);

            Assert.True(result);
        }

        [Fact]
        public void Try_to_schedule_review_in_idela_conditions_NotNull()
        {
            ReviewService reviewService = CreateReviewService();
            ScheduleDTO dto = new ScheduleDTO()
            {
                Priority = bolnica_back.Priority.doctor,
                UserId = 1,
                DoctorId = 1,         //g     M    d,  h, m, s
                FromTime = new DateTime(2022, 10, 10, 10, 0, 0),
                ToTime = new DateTime(2022, 10, 11, 10, 0, 0)
            };

            var result = reviewService.TryToScheduleReviewInIdelaConditions(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public void Try_to_schedule_review_in_idela_conditions_Null()
        {
            ReviewService reviewService = CreateReviewService();
            ScheduleDTO dto = new ScheduleDTO()
            {
                Priority = bolnica_back.Priority.doctor,
                UserId = 1,
                DoctorId = 1,         //g     M    d,  h, m, s
                FromTime = new DateTime(2022, 10, 10, 15, 0, 0),
                ToTime = new DateTime(2022, 10, 11, 10, 0, 0)
            };

            var result = reviewService.TryToScheduleReviewInIdelaConditions(dto);

            Assert.Null(result);
        }

        [Fact]
        public void Find_free_reviews_for_doctor_priority()
        {
            ReviewService reviewService = CreateReviewService();
            ScheduleDTO dto = new ScheduleDTO()
            {
                Priority = bolnica_back.Priority.doctor,
                UserId = 1,
                DoctorId = 1,         //g     M    d,  h, m, s
                FromTime = new DateTime(2022, 10, 10, 15, 0, 0),
                ToTime = new DateTime(2022, 10, 11, 10, 0, 0)
            };

            var result = reviewService.FindFreeReviewsForDoctorPriority(dto);
            //10 dana pre po 1, 10 dana posel po 1 i taj dan = 21
            Assert.Equal(21, result.Count);
        }

        [Fact]
        public void Find_free_reviews_for_time_priority()
        {
            ReviewService reviewService = CreateReviewService();
            ScheduleDTO dto = new ScheduleDTO()
            {
                Priority = bolnica_back.Priority.time,
                UserId = 1,
                DoctorId = 1,         //g     M    d,  h, m, s
                FromTime = new DateTime(2022, 10, 10, 15, 0, 0),
                ToTime = new DateTime(2022, 10, 11, 10, 0, 0)
            };

            var result = reviewService.FindFreeReviewsForTimePriority(dto);
            Assert.NotNull(result);
        }

        private ReviewService CreateReviewService()
        {
            var stubRepo = new Mock<IReviewRepository>();
            var reviews = ListOfReviewsForTesting();

            stubRepo.Setup(m => m.GetAll()).Returns(reviews);
            stubRepo.Setup(m => m.FindById(2000)).Returns(reviews.Find(r => r.Id == 2000));
            stubRepo.Setup(m => m.FindById(2001)).Returns(reviews.Find(r => r.Id == 2001));

            return new ReviewService(stubRepo.Object, CreateDoctrorService(), CreateUserService(), CreateReviewRatingService(),CreatePenaltyPointService());
        }

        private ReviewRatingService CreateReviewRatingService()
        {
            var stubRepo = new Mock<IReviewRatingRepository>();
            var ratings = ListOfReviewRating();

            stubRepo.Setup(m => m.GetAll()).Returns(ratings);

            return new ReviewRatingService(stubRepo.Object);
        }

        private DoctorService CreateDoctrorService()
        {
            var stubRepo = new Mock<IDoctorRepository>();
            var doctors = ListOfDoctorForTesting();

            stubRepo.Setup(m => m.FindById(1)).Returns(doctors.Find(d => d.Id == 1));
            stubRepo.Setup(m => m.FindById(2)).Returns(doctors.Find(d => d.Id == 2));
            stubRepo.Setup(m => m.GetAll()).Returns(doctors);

            return new DoctorService(stubRepo.Object);
        }

        private UserService CreateUserService()
        {
            var stubRepo = new Mock<IUserRepository>();
            var allUser = ListOfUsersForTesting();

            stubRepo.Setup(m => m.GetAll()).Returns(allUser);

            return new UserService(stubRepo.Object, CreatePenaltyPointService());
        }

        private PenaltyPointService CreatePenaltyPointService()
        {
            var stubRepo = new Mock<IPenaltyPointRepository>();
            var points = ListOfPenaltyPoints();

            stubRepo.Setup(m => m.GetAll()).Returns(points);

            return new PenaltyPointService(stubRepo.Object);
        }

        private List<Review> ListOfReviewsForTesting()
        {
            List<Review> reviews = new List<Review>();
            List<Doctor> doctors = this.ListOfDoctorForTesting();
            List<User> users = this.ListOfUsersForTesting();

            //ID = 1 - TESTIRA OTKAZIVANEJ - NE MOZE DA SE OTKAZE
            Review review1 = new Review()
            {
                Id = 2000,
                Doctor = doctors.Find(d => d.Id == 1),
                DoctorId = 1,
                User = users.Find(u => u.Id == 1),
                UserId = 1,
                IsCanceled = false,
                Duration = 30,
                StartTime = new DateTime(2021, 1, 28, 8, 30, 0)
            };

            //ID = 2 - TEST OTKAZIVANJA - MOZE DA SE OTKAZE
            Review review2 = new Review()
            {
                Id = 2001,
                Doctor = doctors.Find(d => d.Id == 1),
                DoctorId = 1,
                User = users.Find(u => u.Id == 1),
                UserId = 1,
                IsCanceled = false,
                Duration = 30,
                StartTime = new DateTime(2022, 12, 28, 14, 30, 0)
            };

            reviews.Add(review1);
            reviews.Add(review2);

            return reviews;
        }

        private List<Doctor> ListOfDoctorForTesting()
        {
            List<Doctor> list = new List<Doctor>();
            Doctor d1 = new Doctor() { Id = 1, Name = "Arandjel", Surname = "Arandjelovic", WorkingDuration = 5, WorkingStart = 10, Specialist = false };
            Doctor d2 = new Doctor() { Id = 2, Name = "Nina", Surname = "Ninic", WorkingDuration =  2, WorkingStart = 8, Specialist = false};
            list.Add(d1);
            list.Add(d2);
            return list;
        }

        private List<User> ListOfUsersForTesting()
        {
            List<User> list = new List<User>();
            User userPera = new User(1, "pera", "123", "Petar", "Petrovic", "123123123", "pp@gmail.com", "Svetosavska 11", "023857197", Gender.m, false);
            User userMika = new User(2, "mika", "123", "Mika", "Mikic", "321321321", "mm@gmail.com", "Dositejeva 2", "023857555", Gender.m, false);
            User userNada = new User(3, "nada", "123", "Nadica", "Nadic", "98989898", "nn@gmail.com", "Pupinova 222", "023857999", Gender.z, true);
            list.Add(userNada);
            list.Add(userMika);
            list.Add(userPera);
            return list;
        }

        private List<PenaltyPoint> ListOfPenaltyPoints()
        {
            List<PenaltyPoint> penaltyPoints = new List<PenaltyPoint>();
            PenaltyPoint pp1 = new PenaltyPoint()
            {
                Id = 1,
                UserId = 1,
                IsDeleted = false,
                WhenRecived = DateTime.Now
            };

            PenaltyPoint pp2 = new PenaltyPoint()
            {
                Id = 2,
                UserId = 1,
                IsDeleted = false,
                WhenRecived = DateTime.Now
            };

            PenaltyPoint pp3 = new PenaltyPoint()
            {
                Id = 3,
                UserId = 1,
                IsDeleted = false,
                WhenRecived = DateTime.Now
            };

            penaltyPoints.Add(pp1);
            penaltyPoints.Add(pp2);
            penaltyPoints.Add(pp3);

            return penaltyPoints;
        }

        private List<ReviewRating> ListOfReviewRating()
        {
            List<ReviewRating> ratings = new List<ReviewRating>();
            ReviewRating r1 = new ReviewRating()
            {
                Id = 1,
                ReviewId = 1,
                Grade = 5,
                Comment = "r1"
            };
            ratings.Add(r1);
            return ratings;
        }
    }
}
