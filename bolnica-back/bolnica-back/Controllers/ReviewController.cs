using bolnica_back.DTOs;
using bolnica_back.Model;
using bolnica_back.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost("addRating")]
        public IActionResult AddReviewRating(RateReviewDTO dto)
        {
            reviewService.AddReviewRating(dto);
            return Ok();
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

        [HttpGet("next/patient/{id}")]
        public IActionResult GetAllNextReviewsOfPatient(long id)
        {
            return Ok(reviewService.GetAllNextReviewsOfPatient(id));
        }

        [HttpGet("next/doctor/{id}")]
        public IActionResult GetAllNextReviewsOfDoctor(long id)
        {
            return Ok(reviewService.GetAllNextReviewsOfDoctor(id));
        }

        [HttpGet("past/patient/{id}")]
        public IActionResult GetAllPastReviewsOfPatient(long id)
        {
            return Ok(reviewService.GetAllPastReviewsOfPatient(id));
        }

        [HttpGet("past/doctor/{id} ")]
        public IActionResult GetAllPastReviewsOfDoctor(long id)
        {
            return Ok(reviewService.GetAllPastReviewsOfDoctor(id));
        }

        [HttpPost("create")]
        public IActionResult CreateReview(ScheduleReviewDTO dto)
        {
            if (reviewService.AddReview(new Review(dto)))
                return Ok();
          
            return NotFound();
        }

        [HttpPost("scheduleReview")]
        public IActionResult ScheduleReview(ScheduleDTO dto)
        {
            if (dto.FromTime <= DateTime.Now) return NotFound();
            List<Review> reviews = new List<Review>();
            Review review = reviewService.TryToScheduleReviewInIdelaConditions(dto);
            if (review != null)
            {
                reviews.Add(review);
                return Ok(ReviewToScheduleReviewDTO(reviews));
            }
            else
            {
                if (dto.Priority == Priority.time) 
                    reviews = reviewService.FindFreeReviewsForTimePriority(dto);
                else 
                    reviews = reviewService.FindFreeReviewsForDoctorPriority(dto);

                if (reviews.Count != 0) 
                    return Ok(ReviewToScheduleReviewDTO(reviews));
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

        private List<ScheduleReviewDTO> ReviewToScheduleReviewDTO(List<Review> reviews)
        {
            List<ScheduleReviewDTO> retVal = new List<ScheduleReviewDTO>();
            foreach (Review r in reviews)
            {
                retVal.Add(new ScheduleReviewDTO(r));
            }
            return retVal;
        }
    }
}
