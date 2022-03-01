using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bolnica_back.Model
{
    public class Review
    {
        [Key]
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public bool IsCanceled { get; set; }
        public long? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Review()
        {
            this.IsCanceled = false;
        }

        public Review(long id, DateTime startTime, int duration, bool isCanceled, Doctor doctor, User user)
        {
            Id = id;
            StartTime = startTime;
            Duration = duration;
            IsCanceled = isCanceled;
            Doctor = doctor;
            User = user;
        }

        public Review(long id, DateTime startTime, int duration, bool isCanceled, int doctorId, int userId)
        {
            Id = id;
            StartTime = startTime;
            Duration = duration;
            IsCanceled = isCanceled;
            DoctorId = doctorId;
            UserId = userId;
        }

        public Review(Review review)
        {
            Id = review.Id;
            StartTime = review.StartTime;
            Duration = review.Duration;
            IsCanceled = review.IsCanceled;
            DoctorId = review.DoctorId;
            UserId = review.UserId;
        }
    }
}
