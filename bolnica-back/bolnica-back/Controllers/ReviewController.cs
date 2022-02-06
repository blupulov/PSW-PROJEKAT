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
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService reviewService;

        public ReviewController(ReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(reviewService.GetAllReviews());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            Review review = reviewService.FindReviewById(id);

            if (review != null)
                return Ok(review);
            else
                return NotFound();
        }
        
        [HttpPost("scheduleReview")]
        public IActionResult scheduleReview(ScheduleDTO scheduleDTO)
        {
            //DA JE PRIORITET VREME SALJE SE NA KANAL SA VREMENOM
            //DA JE PRIORITET DOKTOR SALJE SE NA KANAL SA DOKTOROM

            //U SLUCAJU DA SE PREGLED ODMA ZAKAZE
            return Ok();
            //U NAJGOREM SLUCAJU NOTFOUND
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            reviewService.DeleteReview(id);
            return Ok();
        }

        [HttpPut("cancelReview/{id}")]
        public IActionResult CancelReview(long id)
        {
            if (reviewService.CancleReview(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
