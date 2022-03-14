using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class ScheduleReviewForSpecialistDTO
    {
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public long ReviewId { get; set; }
        public long SpecialistId { get; set; }
    }
}
