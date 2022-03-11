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

        public void UpdateUser(User user)
        {
            User u = this.FindById(user.Id);
            u.Username = user.Username;
            u.Password = user.Password;
            u.Name = user.Name;
            u.Surname = user.Surname;
            u.IsAdmin = user.IsAdmin;
            u.Gender = user.Gender;
            u.Jmbg = user.Jmbg;
            u.PhoneNumber = user.PhoneNumber;
            u.EMail = user.EMail;
            u.Address = user.Address;
            u.IsBlocked = user.IsBlocked;
            ApplicationDbContext.SaveChanges();
        }

    }
}
