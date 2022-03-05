using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class ScheduleReviewDTO
    {
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public long DoctorId { get; set; }
        public long UserId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }

        public ScheduleReviewDTO() { }

        public ScheduleReviewDTO(Review review)
        {
            StartTime = review.StartTime;
            Duration = review.Duration;
            DoctorId = (long)review.DoctorId;
            UserId = (long)review.UserId;
            DoctorName = review.Doctor.Name;
            DoctorSurname = review.Doctor.Surname;
        }
    }
}
