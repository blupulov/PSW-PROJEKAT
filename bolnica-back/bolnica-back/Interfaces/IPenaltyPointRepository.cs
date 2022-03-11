﻿using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Interfaces
{
    public interface IPenaltyPointRepository : IRepository<PenaltyPoint>  
    {
        void LogicalDeleting(List<long> ids);
    }
}
