using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace bolnica_backAppTest.Unit
{
    public class UserServiceTest
    {
        [Fact]
        public void Get_all()
        {
            UserService userService = CreateUserService();

            var allUsers = userService.GetAllUsers();

            Assert.Equal(3, allUsers.Count);
        }

        [Fact]
        public void Login_correct()
        {
            UserService userService = CreateUserService();

            var user = userService.FindRequiredLoginUser("pera", "123");

            Assert.NotNull(user);
        }

        [Fact]
        public void Login_incorrecr()
        {
            UserService userService = CreateUserService();

            var user = userService.FindRequiredLoginUser("pera", "1234");

            Assert.Null(user);
        }
        
        [Fact]
        public void Get_all_suspicious_users()
        {
            UserService userService = CreateUserService();

            var users = userService.GetAllSuspiciousUsers();

            Assert.Single(users);
        }

        [Fact]
        public void Get_all_users_except_admins()
        {
            UserService userService = CreateUserService();

            var users = userService.GetAllUsersExceptAdmins();

            Assert.Equal(2, users.Count);
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
