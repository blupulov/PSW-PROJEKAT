using bolnica_back.DTOs;
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

        public ReviewService(IReviewRepository reviewRepository, DoctorService doctorService)
        {
            this.reviewRepository = reviewRepository;
            this.doctorService = doctorService;
        }

        public List<Review> GetAllReviews()
        {
            return (List<Review>)reviewRepository.GetAll();
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
            Review reviewForCanceling = this.FindReviewById(id);
            DateTime lastMomentForCanceling = reviewForCanceling.StartTime.AddDays(-2);

            if (lastMomentForCanceling < DateTime.Now)
                return false;
            else
                reviewRepository.CancleReview(id);
            return true;
        }

        public List<Review> FindFreeReviewsForDoctorPriority(ScheduleDTO dto)
        {
            List<Review> reviews = new List<Review>();
            return reviews;
        }

        public List<Review> FindFreeReviewsForTimePriority(ScheduleDTO dto)
        {
            List<Review> reviews = new List<Review>();
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
                else UpdateReviewForIdealConditions(review);

                if (review.StartTime >= dto.ToTime)
                    break;
            }
            return null;
        }

        private bool IsPossibleToScheduledReviewInIdelaConditions(Review review, List<Review> doctorReviews)
        {
            foreach (Review r in doctorReviews)
            {
                if (IsReviewsOverlap(r, review) || !IsReviewInDoctorWorkingTime(review))
                    return false;
            }
            return true;
        }

        private bool IsReviewInDoctorWorkingTime(Review review)
        {
            DateTime workingTimeStart = MakeDoctorWorkingTime(review);
            DateTime workingTimeEnd = workingTimeStart.AddHours(review.Doctor.WorkingDuration);
            DateTime reviewEnd = review.StartTime.AddMinutes(review.Duration);

            return reviewEnd >= workingTimeStart && reviewEnd < workingTimeEnd;
        }

        private void UpdateReviewForIdealConditions(Review review)
        {
            if (IsReviewInDoctorWorkingTime(review))
                review.StartTime = review.StartTime.AddMinutes(10);
            else
                CalculateStartTimeOfReviewForIdealConditions(review);
        }

        private void CalculateStartTimeOfReviewForIdealConditions(Review review)
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

        //PRETPOSTAVKA JE DA PREGLED TRAJE POLA SATA
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
            return dto.FromTime <= review.StartTime && reviewOver <= dto.ToTime;
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
    }
}
