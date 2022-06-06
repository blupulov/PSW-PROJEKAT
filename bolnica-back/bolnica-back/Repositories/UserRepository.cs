using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void BlockUser(long id)
        {
            User u = FindById(id);
            u.IsBlocked = true;
            ApplicationDbContext.SaveChanges();
        }

        public void UnblockUser(long id)
        {
            User u = FindById(id);
            u.IsBlocked = false;
            ApplicationDbContext.SaveChanges();
        }

        public void UpdateUser(ChangePersonalInfoDTO dto)
        {
            User u = this.FindById(dto.Id);
            u.Name = dto.Name;
            u.Surname = dto.Surname;
            u.Jmbg = dto.Jmbg;
            u.PhoneNumber = dto.PhoneNumber;
            u.EMail = dto.EMail;
            u.Address = dto.Address;
            if (dto.Gender == "m")
                u.Gender = Gender.m;
            else
                u.Gender = Gender.z;

            ApplicationDbContext.SaveChanges();
        }

    }
}
