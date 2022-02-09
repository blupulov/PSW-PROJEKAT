using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Repositories;
using bolnica_back.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bolnica_backAppTest
{
    public class ReviewServiceTest
    {
        [Fact]
        public void Can_review_be_canceled_yes() 
        {
            //var stubRepo = new Mock<ReviewRepository>();
            //var reviews = ListOfReviewsForTesting();
            //stubRepo.Setup(m => m.GetAll()).Returns(reviews);

            //ReviewService reviewService = new ReviewService(stubRepo.Object);
            //var allReviews = reviewService.GetAllReviews();
            
            //Assert.NotNull(allReviews);
        }

        private List<Review> ListOfReviewsForTesting()
        {
            List<Review> reviews = new List<Review>();
            List<Doctor> doctors = this.ListOfDoctorForTesting();
            List<User> users = this.ListOfUsersForTesting();

            //ID = 1 - TESTIRA OTKAZIVANEJ - NE MOZE DA SE OTKAZE
            Review review1 = new Review()
            {
                Id = 1,
                Doctor = doctors.Find(d => d.Id == 1),
                User = users.Find(u => u.Id == 1),
                IsCanceled = false,
                Duration = 30,
                StartTime = new DateTime(2021, 1, 28, 8, 30, 0)
            };

            //ID = 2 - TEST OTKAZIVANJA - MOZE DA SE OTKAZE
            Review review2 = new Review()
            {
                Id = 2,
                Doctor = doctors.Find(d => d.Id == 1),
                User = users.Find(u => u.Id == 1),
                IsCanceled = false,
                Duration = 30,
                StartTime = new DateTime(2021, 12, 28, 14, 30, 0)
            };

            reviews.Add(review1);
            reviews.Add(review2);

            return reviews;
        }

        private List<Doctor> ListOfDoctorForTesting()
        {
            List<Doctor> list = new List<Doctor>();
            Doctor doctorArandjel = new Doctor() { Id = 1, Name = "Arandjel", Surname = "Arandjelovic" };
            Doctor doctorNina = new Doctor() { Id = 2, Name = "Nina", Surname = "Ninic" };
            list.Add(doctorArandjel);
            list.Add(doctorNina);
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
    }
}
