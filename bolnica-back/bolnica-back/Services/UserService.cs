using bolnica_back.Model;
using bolnica_back.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers() 
        {
            return userRepository.GetAllUsers();
        }

        public User FindUserById(long id) 
        {
            return userRepository.FindUserById(id);
        }

        public User FindRequiredLoginUser(string username, string password) 
        {
            foreach (User user in userRepository.GetAllUsers()) 
            {
                if (user.Username == username && user.Password == password)
                    return user;
            }
            return null;
        }

        public void DeleteUser(User user) 
        {
            userRepository.DeleteUser(user);
        }

        public bool SaveUser(User user) 
        {
            if (IsUserValidForAdding(user))
            {
                userRepository.SaveUser(user);
                return true;
            }
            else 
                return false;

        }

        public bool UpdateUser(User user)
        {
            if (IsUserValidForAdding(user))
            {
                userRepository.UpdateUser(user);
                return true;
            }
            else
                return false;
                
        }

        private bool IsUserValidForAdding(User user)
        {
            foreach (User u in userRepository.GetAllUsers()) {
                if (u.Username == user.Username && u.Id != user.Id)
                    return false;
            }
            return true;
        }
    }
}
