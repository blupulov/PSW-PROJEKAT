using bolnica_back.Controllers;
using bolnica_back.Model;
using bolnica_back.Repositories;
using bolnica_back.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace bolnica_backAppTest
{
    public class UserServiceTests
    {
        private readonly UserController userController;
        
        public UserServiceTests(UserController userController)
        {
            this.userController = userController;
        }

        [Fact]
        public void Find_user_by_id()
        {
            User user = (User)userController.GetUserById(1L);

            Assert.NotNull(user);
        }

        
    }
}
