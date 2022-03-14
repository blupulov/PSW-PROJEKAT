using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bolnica_back.Model
{
    public class Doctor
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public List<Review> Reviews { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public int WorkingDuration { get; set; }
        public int WorkingStart { get; set; }
        public bool Specialist { get; set; }
        public Doctor() { }

        public Doctor(long id)
        {
            this.Id = id;
        }

        public Doctor(long id, string name, string surname, string username, string eMail, string phone, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            EMail = eMail;
            Phone = phone;
            Password = password;
        }

        public Doctor(long id, string name, string surname, string username, string eMail, string phone, string password, int workingDuration, int workingStart)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            EMail = eMail;
            Phone = phone;
            Password = password;
            WorkingDuration = workingDuration;
            WorkingStart = workingStart;
            Specialist = false;
        }

        public Doctor(long id, string name, string surname, string username, string eMail, string phone, string password, int workingDuration, int workingStart, bool spec)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            EMail = eMail;
            Phone = phone;
            Password = password;
            WorkingDuration = workingDuration;
            WorkingStart = workingStart;
            Specialist = spec;
        }
    }
}
