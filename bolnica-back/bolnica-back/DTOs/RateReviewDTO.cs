using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class RateReviewDTO
    {
        public long ReviewId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }

        public RateReviewDTO() { }
        public RateReviewDTO(long reviewId, int grade, string comment) 
        {
            ReviewId = reviewId;
            Grade = grade;
            Comment = comment;
        }
    }
}
