using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class ReviewInstructions
    {
        [Key]
        public long Id { get; set; }
        public long ReviewId { get; set; }
        public Review Review { get; set; }
        public string Reason { get; set; }

        public ReviewInstructions()
        {

        }
    }
}
