using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace bolnica_backAppTest.Unit
{
    public class PenaltyPointServiceTest
    {   
        [Fact]
        public void Get_all_penalty_points()
        {
            PenaltyPointService penaltyPointService = CreatePenaltyPointService();

            var allPoints = penaltyPointService.GetAll();

            Assert.Equal(3, allPoints.Count);
        }

        [Fact]
        public void Get_number_of_user_penalty_points_in_last_month()
        {
            PenaltyPointService penaltyPointService = CreatePenaltyPointService();

            int numberOfPoints = penaltyPointService.GetNumberOfUserPenaltyPointsInLastMonth(1);

            Assert.Equal(3, numberOfPoints);
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
    }
}
