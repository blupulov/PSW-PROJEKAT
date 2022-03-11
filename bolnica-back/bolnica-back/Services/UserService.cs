using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;

namespace bolnica_back.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly PenaltyPointService penaltyPointService;

        public UserService(IUserRepository userRepository, PenaltyPointService penaltyPointService)
        {
            this.userRepository = userRepository;
            this.penaltyPointService = penaltyPointService;
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
                if (user.Username == username && user.Password == password && !user.IsBlocked)
                    return user;
            }
            return null;
        }

        internal object GetAllUsersExceptAdmins()
        {
            List<UserDTO> dtos = new List<UserDTO>();
            foreach(User u in GetAllUsers())
            {
                if (!u.IsAdmin)
                    dtos.Add(u.ConvertToUserDTO());
            }
            return dtos;
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

        public void BlockUser(long id)
        {
            userRepository.BlockUser(id);
        }

        public void UnblockUser(long id)
        {
            userRepository.UnblockUser(id);
        }

        public List<UserDTO> GetAllSuspiciousUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach(User u in GetAllUsers())
            {
                int userPenaltyPoints = penaltyPointService.GetNumberOfUserPenaltyPointsInLastMonth(u.Id);
                if (userPenaltyPoints >= 3) 
                {
                    UserDTO dto = new UserDTO(u, userPenaltyPoints);
                    users.Add(dto);
                }
                    
            }
            return users;
        }

        public void ClearSuspciousUser(long id)
        {
            penaltyPointService.ClearAllPenaltyPointsOfUser(id);
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
