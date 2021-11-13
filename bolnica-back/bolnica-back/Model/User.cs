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
        public string Gender { get; set; }
        public string Role { get; set; }
        public bool IsBlocked { get; set; }

        public User()
        {

        }

        public User(long id, string username, string password, string name, string surname, string jmbg, string eMail, string address, string phoneNumber,
            string gender, string role)
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
            Role = role;
            IsBlocked = false;
        }
    }
}
