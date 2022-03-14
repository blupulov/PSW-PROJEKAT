using bolnica_back.DTOs;
using bolnica_back.Model;
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
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService doctorService;

        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(doctorService.GetAll());
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
        {
            UserDTO dto = doctorService.Login(username, password);
            if (dto != null)
                return Ok(dto);
            else
                return NotFound("Korisnik sa prosledjenim kredencijaima nije pronadjen.");
        }

        [HttpGet("nonSpecialist")]
        public IActionResult GetAllNotSpecialist()
        {
            return Ok(doctorService.GetAllNonSpecialistDoctors());
        }
        
        [HttpGet("specialist")]
        public IActionResult GetAllSpecialist()
        {
            List<Doctor> doctors = doctorService.GetAllSpecialistDoctrs();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            Doctor doctor = doctorService.FindById(id);

            if (doctor != null)
                return Ok(doctor);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Save(Doctor doctor)
        {
            doctorService.Add(doctor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            doctorService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDoctor(ChangePersonalInfoDTO dto)
        {
            doctorService.UpdateDoctor(dto);
            return Ok();
        }
    }
}
