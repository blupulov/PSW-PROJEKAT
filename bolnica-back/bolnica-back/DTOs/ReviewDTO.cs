using bolnica_back.Model;
using System;

namespace bolnica_back.DTOs
{
    public class ReviewDTO
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public bool IsRated { get; set; }

        public ReviewDTO(Review review)
        {
            Id = review.Id;
            StartTime = review.StartTime;
            Duration = review.Duration;
            DoctorName = review.Doctor.Name;
            DoctorSurname = review.Doctor.Surname;
            PatientName = review.User.Name;
            PatientSurname = review.User.Surname;
            if (review.Rating != null) 
            {
                IsRated = true;
            }         
        }
    }
}
