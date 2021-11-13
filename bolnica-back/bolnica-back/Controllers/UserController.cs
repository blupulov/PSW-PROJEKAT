using bolnica_back.Model;
using bolnica_back.Repositories;
using bolnica_back.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //izbaciti enumeracije ili preko dto ili u klasi
        private readonly UserService userService;
        public UserController(UserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id) 
        {
            User user = userService.FindUserById(id);

            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpGet("login")]
        public IActionResult GetUserByUsernameAndPassword([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password) 
        {
            User user = userService.FindRequiredLoginUser(username, password);

            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult SaveUser(User user) 
        {
            bool isUserSaved = userService.SaveUser(user);
            
            if (isUserSaved)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteUser(User user) 
        {
            userService.DeleteUser(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user) 
        {
            bool isValid = userService.UpdateUser(user);
            
            if (isValid)
                return Ok();
            else
                return BadRequest();
        }
    }
}
