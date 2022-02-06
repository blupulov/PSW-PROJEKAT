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

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public List<Review> GetAllReviews()
        {
            return (List<Review>)reviewRepository.GetAll();
        }

        public void AddReview(Review review)
        {
            reviewRepository.Add(review);
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

        //PROVERITI DA LI JE ODABRAN LEKAR SLOBODAN U NEKOM ODABRANOM VREMENU NA PRVI SLOBODAN TERMIN SE ZAKAZUJE I VRACA TRUE 
        public bool TryToScheduleReviewByOriginalUserWish(ScheduleDTO scheduleDTO)
        {
            throw new NotImplementedException();
        }

        //DOKTOR SE NE MENJA SAMO SE PRONALAZI KADA JE SLOBODAN +- 10 DANA OD POCETKA I KRAJA ODABRANOG TERMINA
        public List<Review> DoctroPriorityReviews(ScheduleDTO scheduleDTO)
        {
            throw new NotImplementedException();
        }

        //NE DIRA SE VREMENSKI INTERVAL SAMO SE DOKTORI MENJAJU
        public List<Review> TimeSpanPriorityReviews(ScheduleDTO scheduleDTO)
        {
            throw new NotImplementedException();
        }
    }
}
