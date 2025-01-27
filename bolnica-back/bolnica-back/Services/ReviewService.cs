﻿using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;

namespace bolnica_back.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository reviewRepository;
        private readonly DoctorService doctorService;
        private readonly UserService userService;
        private readonly ReviewRatingService reviewRatingService;
        private readonly PenaltyPointService penaltyPointService;

        public ReviewService(IReviewRepository reviewRepository,
            DoctorService doctorService, UserService userService, ReviewRatingService reviewRatingService, PenaltyPointService penaltyPointService)
        {
            this.reviewRepository = reviewRepository;
            this.doctorService = doctorService;
            this.userService = userService;
            this.reviewRatingService = reviewRatingService;
            this.penaltyPointService = penaltyPointService;
        }

        public List<Review> GetAllReviews()
        {
            return (List<Review>)reviewRepository.GetAll();
        }

        public List<ReviewDTO> GetAllTodaysReviewsOfDoctor(long doctorId)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            foreach(Review r in GetAllReviews())
            {
                if (IsReviewToday(r.StartTime) && !r.IsCanceled && r.DoctorId == doctorId) 
                {
                    r.Doctor = doctorService.FindById((long)r.DoctorId);
                    r.User = userService.FindUserById((long)r.UserId);
                    reviews.Add(new ReviewDTO(r));
                }
                    
            }
            return reviews;
        }

        public bool AddReview(Review review)
        {
            if (IsPossibleToScheduledReview(review))
            {
                reviewRepository.Add(review);
                return true;
            }
            return false;
        }

        public Review FindReviewById(long id)
        {
            return reviewRepository.FindById(id);
        }

        public void DeleteReview(long id)
        {
            reviewRepository.Delete(FindReviewById(id));
        }

        public bool CancleReview(long id)
        {
            Review reviewForCanceling = FindReviewById(id);
            DateTime lastMomentForCanceling = reviewForCanceling.StartTime.AddDays(-2);

            if (lastMomentForCanceling < DateTime.Now)
                return false;

            reviewRepository.CancleReview(id);
            penaltyPointService.AddPenaltyPointToUser((long)reviewForCanceling.UserId);

            return true;
        }

        public List<Review> FindFreeReviewsForDoctorPriority(ScheduleDTO dto)
        {
            List<Review> reviews = new List<Review>();
            ChangeScheduleDTOFromAndToTimeForDoctorPriority(dto);
            Review review = MakeNewReview(dto);
            while (review.StartTime <= dto.ToTime)
            {
                if (reviews.Count >= 50) break;

                if (IsPossibleToScheduledReview(review) && IsReviewInDoctorWorkingTime(review))
                {
                    reviews.Add(new Review(review));
                    UpdateStartTimeOfReviewForDoctorPriority(review);
                }else
                    UpdateStartTimeOfReviewForScheduling(review);
            }
            return reviews;
        }

        public List<Review> FindFreeReviewsForTimePriority(ScheduleDTO dto)
        {
            List<Review> reviews = new List<Review>();
            foreach (Doctor d in doctorService.GetAllNonSpecialistDoctors())
            {
                if (dto.DoctorId == d.Id) continue;
                dto.DoctorId = d.Id;
                CollectFreeReviewsOfDoctorForTimePriority(reviews, dto);
                if (reviews.Count >= 10) break;
            }
            return reviews;
        }

        public Review TryToScheduleReviewInIdelaConditions(ScheduleDTO dto)
        {
            Review review = MakeNewReview(dto);
            List<Review> doctorReviews = GetAllReviewsOfDoctorInSpecificTimespan(dto);
            while (true)
            {
                if (IsPossibleToScheduledReviewInIdelaConditions(review, doctorReviews))
                    return review;
                else UpdateStartTimeOfReviewForScheduling(review);

                if (review.StartTime >= dto.ToTime)
                    break;
            }
            return null;
        }

        public List<ReviewDTO> GetAllNextReviewsOfPatient(long patientId)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            foreach(Review r in GetAllReviews())
                if (r.UserId == patientId && !r.IsCanceled && r.StartTime >= DateTime.Now)
                {
                    r.User = userService.FindUserById(patientId);
                    r.Doctor = doctorService.FindById((long)r.DoctorId);
                    reviews.Add(new ReviewDTO(r));
                }

            return reviews;
        }

        public List<ReviewDTO> GetAllNextReviewsOfDoctor(long doctorId)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            foreach (Review r in GetAllReviews())
                if (r.DoctorId == doctorId && !r.IsCanceled && r.StartTime >= DateTime.Now)
                {
                    r.User = userService.FindUserById((long)r.UserId);
                    r.Doctor = doctorService.FindById(doctorId);
                    reviews.Add(new ReviewDTO(r));
                }
                   
            return reviews;
        }

        public List<ReviewDTO> GetAllPastReviewsOfPatient(long patientId)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            foreach (Review r in GetAllReviews())
                if (r.UserId == patientId && !r.IsCanceled && r.StartTime <= DateTime.Now)
                {
                    r.Rating = reviewRatingService.FindByReviewId(r.Id);
                    r.User = userService.FindUserById(patientId);
                    r.Doctor = doctorService.FindById((long)r.DoctorId);
                    reviews.Add(new ReviewDTO(r));
                }   

            return reviews;
        }

        public List<ReviewDTO> GetAllPastReviewsOfDoctor(long doctorId)
        {
            List<ReviewDTO> reviews = new List<ReviewDTO>();
            foreach (Review r in GetAllReviews())
                if (r.DoctorId == doctorId && !r.IsCanceled && r.StartTime <= DateTime.Now) 
                {
                    r.User = userService.FindUserById((long)r.UserId);
                    r.Doctor = doctorService.FindById(doctorId);
                    reviews.Add(new ReviewDTO(r));
                }

            return reviews;
        }

        public void AddReviewRating(RateReviewDTO dto)
        {
            reviewRepository.AddReviewRating(new ReviewRating(dto));
        }

        private bool IsPossibleToScheduledReviewInIdelaConditions(Review review, List<Review> doctorReviews)
        {
            if (!IsReviewInDoctorWorkingTime(review))
                return false;

            foreach (Review r in doctorReviews)
            {
                if (IsReviewsOverlap(r, review))
                    return false;
            }
            return true;
        }

        private bool IsReviewInDoctorWorkingTime(Review review)
        {
            DateTime workingTimeStart = MakeDoctorWorkingTime(review);
            DateTime workingTimeEnd = workingTimeStart.AddHours(review.Doctor.WorkingDuration);
            DateTime reviewEnd = review.StartTime.AddMinutes(review.Duration);

            return reviewEnd >= workingTimeStart && reviewEnd <= workingTimeEnd;
        }

        private void UpdateStartTimeOfReviewForScheduling(Review review)
        {
            if (IsReviewInDoctorWorkingTime(review))
                review.StartTime = review.StartTime.AddMinutes(10);
            else
                CalculateStartTimeOfReviewForScheduling(review);
        }

        private void CalculateStartTimeOfReviewForScheduling(Review review)
        {
            DateTime workingTimeStart = MakeDoctorWorkingTime(review);
            DateTime reviewEnd = review.StartTime.AddMinutes(review.Duration);

            if (reviewEnd <= workingTimeStart)
                review.StartTime = workingTimeStart;
            else
                review.StartTime = workingTimeStart.AddDays(1);
        }

        private DateTime MakeDoctorWorkingTime(Review review)
        {
            return new DateTime(review.StartTime.Year, review.StartTime.Month, review.StartTime.Day, review.Doctor.WorkingStart, 0, 0);
        }

        private Review MakeNewReview(ScheduleDTO dto)
        {
            return new Review() { DoctorId = dto.DoctorId, UserId = dto.UserId, Duration = 30, StartTime = dto.FromTime, Doctor = doctorService.FindById(dto.DoctorId) };
        }

        private List<Review> GetAllReviewsOfDoctorInSpecificTimespan(ScheduleDTO dto)
        {
            List<Review> reviews = new List<Review>();
            foreach (Review r in GetAllReviews())
            {
                if (r.DoctorId == dto.DoctorId && IsReviewInSpecificTimespan(r, dto) && !r.IsCanceled)
                    reviews.Add(r);
            }
            return reviews;
        }

        private bool IsReviewInSpecificTimespan(Review review, ScheduleDTO dto)
        {
            DateTime reviewOver = review.StartTime.AddMinutes(review.Duration);
            DateTime lastTimeToSchedule = dto.ToTime.AddMinutes(30);
            if (review.StartTime >= dto.FromTime && reviewOver <= lastTimeToSchedule)
                return true;
            return false;
        }

        private bool IsReviewsOverlap(Review exist, Review possible)
        {
            DateTime existOver = exist.StartTime.AddMinutes(exist.Duration);
            DateTime possibleOver = possible.StartTime.AddMinutes(possible.Duration);

            if (possible.StartTime >= exist.StartTime && possible.StartTime <= existOver) return true;
            else if (possibleOver >= exist.StartTime && possibleOver <= existOver) return true;
            else if (exist.StartTime >= possible.StartTime && exist.StartTime <= possibleOver) return true;
            else return false;
        }

        private bool IsPossibleToScheduledReview(Review review)
        {
            foreach (Review r in GetAllReviews())
                if (r.DoctorId == review.DoctorId && IsReviewsOverlap(r, review))
                    return false;
            return true;
        }

        private void UpdateStartTimeOfReviewForDoctorPriority(Review review)
        {
            DateTime workingTimeStart = MakeDoctorWorkingTime(review);
            review.StartTime = workingTimeStart.AddDays(1);
        }

        private void ChangeScheduleDTOFromAndToTimeForDoctorPriority(ScheduleDTO dto)
        {
            dto.ToTime = dto.ToTime.AddDays(10);
            var timeBetween = DateTime.Now.Subtract(dto.FromTime);
            if (timeBetween.Days < -10)
                dto.FromTime = dto.FromTime.AddDays(-10);
            else
                dto.FromTime = dto.FromTime.AddDays(timeBetween.Days);
        }

        private void CollectFreeReviewsOfDoctorForTimePriority(List<Review> reviews, ScheduleDTO dto)
        {
            List<Review> doctorReviews = GetAllReviewsOfDoctorInSpecificTimespan(dto);
            Review review = MakeNewReview(dto);
            while (dto.ToTime >= review.StartTime)
            {
                if (IsPossibelToAddReviewForTimePriority(review, doctorReviews))
                    reviews.Add(new Review(review));

                if (reviews.Count >= 10) break;

                UpdateStartTimeOfReviewForScheduling(review);
            }
        }

        private bool IsPossibelToAddReviewForTimePriority(Review review, List<Review> doctorReviews)
        {
            if (!IsReviewInDoctorWorkingTime(review))
                return false;

            foreach (Review r in doctorReviews)
                if (IsReviewsOverlap(r, review))
                    return false;

            return true;
        }

        private bool IsReviewToday(DateTime reviewStartTime)
        {
            return reviewStartTime.Year == DateTime.Now.Year && reviewStartTime.Month == DateTime.Now.Month && reviewStartTime.Day == DateTime.Now.Day;
        }

        public bool ScheduleReviewForSpecialist(ScheduleReviewForSpecialistDTO dto)
        {
            Review review = MakeReviewForSpecialist(dto);

            if (!IsPossibleToScheduledReview(review) || !IsReviewInDoctorWorkingTime(review))
                return false;

            reviewRepository.Add(review);

            return true;
        }

        private Review MakeReviewForSpecialist(ScheduleReviewForSpecialistDTO dto)
        {
            ReviewInstructions instructions = new ReviewInstructions();
            instructions.Reason = dto.Instructions;

            Review existReview = FindReviewById(dto.ReviewId);

            Review review = new Review(dto, (long)existReview.UserId, instructions);
            review.Doctor = doctorService.FindById((long)review.DoctorId);
            return review;
        }
    }
}
