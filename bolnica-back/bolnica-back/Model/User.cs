using bolnica_back.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public long Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jmbg { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Survey> Surveys { get; set; }
        public List<PenaltyPoint> PenaltyPoints { get; set; } 

        public User()
        {

        }

        public User(long id)
        {
            this.Id = id;
        }

        public User(long id, string username, string password, string name, string surname, string jmbg, string eMail, string address, string phoneNumber,
            Gender gender, bool isAdmin)
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
            Gender = gender;
            IsAdmin = isAdmin;
            IsBlocked = false;
        }

        public UserDTO ConvertToUserDTO() 
        {
            UserDTO userDTO = new UserDTO
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
            if (this.Gender == Gender.m)
                userDTO.Gender = "m";
            else
                userDTO.Gender = "z";

            return userDTO;
        }
    }
}
