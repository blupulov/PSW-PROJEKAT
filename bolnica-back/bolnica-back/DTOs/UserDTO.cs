using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jmbg { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }

        public UserDTO(){ }

        public UserDTO(long id, string username, string password, string name, string surname, string jmbg, string eMail, string address,
            string phoneNumber, Gender gender, bool isAdmin, bool isBlocked)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            EMail = eMail;
            Address = address;
            PhoneNumber = phoneNumber;
            Gender = gender.ToString();
            IsAdmin = isAdmin;
            IsBlocked = isBlocked;
        }

        public User ConvertToUser() {
            User user = new User
            {
                Id = this.Id,
                Username = this.Username,
                Password = this.Password,
                Name = this.Name,
                Surname = this.Surname,
                Jmbg = this.Jmbg,
                EMail = this.EMail,
                Address = this.Address,
                PhoneNumber = this.PhoneNumber,
                IsAdmin = this.IsAdmin,
                IsBlocked = this.IsBlocked
            };
            if (this.Gender == "m")
                user.Gender = global::Gender.m;
            else
                user.Gender = global::Gender.z;
            
            return user;
        }
    }
}
