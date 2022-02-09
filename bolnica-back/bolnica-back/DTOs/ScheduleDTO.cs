using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class ScheduleDTO
    {
        public Priority Priority { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public long DoctorId { get; set; }
        public long UserId { get; set; }
        
        public ScheduleDTO() { }

        public ScheduleDTO(Priority priority, DateTime fromTime, DateTime toTime, long doctorId, long userId)
        {
            Priority = priority;
            FromTime = fromTime;
            ToTime = toTime;
            DoctorId = doctorId;
            UserId = userId;
        }
    }
}
