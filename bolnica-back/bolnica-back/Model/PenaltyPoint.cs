using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class PenaltyPoint
    {
        [Key]
        public long Id { get; set; }
        public DateTime WhenRecived { get; set; }
        public bool IsDeleted { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

        public PenaltyPoint() { }

        public PenaltyPoint(long userId) 
        {
            IsDeleted = false;
            WhenRecived = DateTime.Now;
            UserId = userId;
        }
    }
}
