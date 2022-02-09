using bolnica_back.DTOs;
using bolnica_back.Model;
using bolnica_back.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult ScheduleReview(ScheduleDTO dto)
        {
            List<Review> reviews = new List<Review>();
            Review review = reviewService.TryToScheduleReviewInIdelaConditions(dto);
            if (review != null)
            {
                reviews.Add(review);
                return Ok(reviews);
            }
            else
            {
                if (dto.Priority == Priority.time) 
                    reviews = reviewService.FindFreeReviewsForTimePriority(dto);
                else 
                    reviews = reviewService.FindFreeReviewsForDoctorPriority(dto);

                if (reviews.Count != 0) 
                    return Ok(reviews);
            }
            return NotFound();
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
