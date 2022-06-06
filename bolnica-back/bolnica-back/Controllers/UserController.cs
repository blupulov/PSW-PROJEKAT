using bolnica_back.DTOs;
using bolnica_back.Model;
using bolnica_back.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace bolnica_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (User user in userService.GetAllUsers())
            {
                userDTOs.Add(user.ConvertToUserDTO());
            }

            return Ok(userDTOs);
        }

        [HttpGet("suspicious")]
        public IActionResult GetAllSuspiciousUsers()
        {
            return Ok(userService.GetAllSuspiciousUsers());
        }

        [HttpGet("allUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsersExceptAdmins());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            User user = userService.FindUserById(id);
            UserDTO userDTO = user.ConvertToUserDTO();

            if (user != null)
                return Ok(userDTO);
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
                return NotFound("Korisnik sa prosledjenim kredencijaima nije pronadjen.");
        }

        [HttpPost]
        public IActionResult SaveUser(UserDTO userDTO)
        {
            User user = userDTO.ConvertToUser();
            bool isUserSaved = userService.SaveUser(user);
            if (isUserSaved)
                return Ok();
            else
                return BadRequest("Došlo je do greške prilikom upisivanja korisnika.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            userService.DeleteUser(id);
            return Ok();
        }

        [HttpPut("clearSuspiciousUser/{id}")]
        public IActionResult ClearSuspciousUser(long id)
        {
            userService.ClearSuspciousUser(id);
            return Ok();
        }

        [HttpPut("block/{id}")]
        public IActionResult BlockUser(long id)
        {
            userService.BlockUser(id);
            return Ok();
        }

        [HttpPut("unblock/{id}")]
        public IActionResult UnblockUser(long id)
        {
            userService.UnblockUser(id);
            return Ok();
        }

        [HttpPut("changeUser/{id}")]
        public IActionResult UpdateUser(ChangePersonalInfoDTO dto, long id) 
        {
            dto.Id = id;
            //System.Diagnostics.Debug.WriteLine(dto.ToString());
            userService.UpdateUser(dto);
            return Ok();
        }
    }
}
