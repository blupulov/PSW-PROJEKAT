using bolnica_back.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolnica_back.Model
{
    public class Survey
    {
        public long Id { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public Survey() { }
        public Survey(long id, int grade, string comment, DateTime creationDate, long userId, bool isAnonymous) 
        {
            Id = id;
            Grade = grade;
            Comment = comment;
            CreationDate = creationDate;
            UserId = userId;
            IsAnonymous = isAnonymous;
            IsPublished = false;
        }

        public Survey(CreateSurveyDTO dto)
        {
            Grade = dto.Grade;
            Comment = dto.Comment;
            IsAnonymous = dto.IsAnonymous;
            UserId = dto.UserId;
            IsPublished = false;
            CreationDate = DateTime.Now;
        }
    }
}
