using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class CreateSurveyDTO
    {
        public long UserId { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Grade { get; set; }

        public CreateSurveyDTO() { }
    }
}
