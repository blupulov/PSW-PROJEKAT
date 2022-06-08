using bolnica_back.Controllers;
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
    public class UserServiceTest
    {
        [Fact]
        public void Get_all()
        {
            UserService userService = CreateUserService();
            UserController userController = new UserController(userService);

            var allUsers = userController.GetAllUsers();

            Assert.NotNull(allUsers);
        }

        [Fact]
        public void Get_by_id()
        {
            UserService userService = CreateUserService();
            UserController userController = new UserController(userService);

            var userPera = userController.GetUserById(1);

            Assert.NotNull(userPera);
        }

        [Fact]
        public void Get_user_by_username_and_password()
        {
            UserService userService = CreateUserService();
            UserController userController = new UserController(userService);

            var userPera = userController.GetUserByUsernameAndPassword("pera", "1234");

            Assert.NotNull(userPera);
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
