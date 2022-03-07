using bolnica_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.DTOs
{
    public class SurveyDTO
    {
        public long Id { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsPublished { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserUsername { get; set; }

        public SurveyDTO() { }

        public SurveyDTO(Survey survey)
        {
            Id = survey.Id;
            Grade = survey.Grade;
            Comment = survey.Comment;
            IsAnonymous = survey.IsAnonymous;
            IsPublished = survey.IsPublished;
            UserName = survey.User.Name;
            UserSurname = survey.User.Surname;
            UserUsername = survey.User.Username;
        }
    }
}
