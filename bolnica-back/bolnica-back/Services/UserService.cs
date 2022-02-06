﻿using bolnica_back.Interfaces;
using bolnica_back.Model;
using System.Collections.Generic;

namespace bolnica_back.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers() 
        {
            return (List<User>)userRepository.GetAll();
        }

        public User FindUserById(long id) 
        {
            return userRepository.FindById(id);
        }

        public User FindRequiredLoginUser(string username, string password) 
        {
            foreach (User user in this.GetAllUsers()) 
            {
                if (user.Username == username && user.Password == password)
                    return user;
            }
            return null;
        }

        public void DeleteUser(long id) 
        {
            User user = this.FindUserById(id);
            userRepository.Delete(user);
        }

        public bool SaveUser(User user) 
        {
            if (IsUserValidForAdding(user))
            {
                userRepository.Add(user);
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
            foreach (User u in this.GetAllUsers()) {
                if (u.Username == user.Username && u.Id != user.Id)
                    return false;
            }
            return true;
        }
    }
}
