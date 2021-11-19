﻿using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void UpdateUser(User user);
    }
}