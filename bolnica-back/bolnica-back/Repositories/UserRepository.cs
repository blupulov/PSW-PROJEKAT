using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> GetAllUsers() 
        {
            return dbContext.Users.ToList();
        }

        public User FindUserById(long id) 
        {
            return dbContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public void SaveUser(User user) 
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void UpdateUser(User user) 
        {
            User u = dbContext.Users.SingleOrDefault(u => u.Id == user.Id);
            u.Username = user.Username;
            u.Password = user.Password;
            u.Name = user.Name;
            u.Surname = user.Surname;
            u.Role = user.Role;
            u.Gender = user.Gender;
            u.Jmbg = user.Jmbg;
            u.PhoneNumber = user.PhoneNumber;
            u.EMail = user.EMail;
            u.Address = user.Address;
            u.IsBlocked = user.IsBlocked;
            dbContext.SaveChanges();
        }

        public void DeleteUser(User user) 
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
    }
}
