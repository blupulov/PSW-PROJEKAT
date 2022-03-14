using bolnica_back.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Services
{
    public class ReviewInstructionsService
    {
        private readonly IReviewInstructionsRepository instructionsRepository;

        public ReviewInstructionsService(IReviewInstructionsRepository instructionsRepository)
        {
            this.instructionsRepository = instructionsRepository;
        }

    }
}
