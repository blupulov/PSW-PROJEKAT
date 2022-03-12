using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace bolnica_backAppTest.Unit
{
    public class SurveyServiceTest
    {

        [Fact]
        public void Get_all()
        {
            SurveyService surveyService = CreateSurveyService();

            var allSurveys = surveyService.GetAll();

            Assert.Equal(2, allSurveys.Count);
        }

        [Fact]
        public void Get_all_published_surveys()
        {
            SurveyService surveyService = CreateSurveyService();

            var publishedSurveys = surveyService.GetAllPublishedSurveys();

            Assert.Single(publishedSurveys);
        }

        private SurveyService CreateSurveyService()
        {
            var stubRepo = new Mock<ISurveyRepository>();
            var surveys = ListOfSurveys();

            stubRepo.Setup(m => m.GetAll()).Returns(surveys);

            return new SurveyService(stubRepo.Object, CreateUserService());
        }

        private UserService CreateUserService()
        {
            var stubRepo = new Mock<IUserRepository>();
            stubRepo.Setup(m => m.FindById(1)).Returns(new User(1));

            return new UserService(stubRepo.Object, CreatePenaltyPointService());
        }

        private PenaltyPointService CreatePenaltyPointService()
        {
            var stubRepo = new Mock<IPenaltyPointRepository>();
            var points = ListOfPenaltyPoints();

            stubRepo.Setup(m => m.GetAll()).Returns(points);

            return new PenaltyPointService(stubRepo.Object);
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

        private List<Survey> ListOfSurveys()
        {
            List<Survey> surveys = new List<Survey>();

            Survey s1 = new Survey()
            {
                Id = 1,
                UserId = 1,
                CreationDate = DateTime.Now,
                Grade = 5,
                IsAnonymous = false,
                IsPublished = true,
                Comment = "1"
            };

            Survey s2 = new Survey()
            {
                Id = 2,
                UserId = 1,
                CreationDate = DateTime.Now,
                Grade = 5,
                IsAnonymous = false,
                IsPublished = false,
                Comment = "2"
            };

            surveys.Add(s1);
            surveys.Add(s2);

            return surveys;
        }
    }
}
