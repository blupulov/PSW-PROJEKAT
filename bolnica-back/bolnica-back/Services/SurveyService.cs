using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;
using System.Collections.Generic;

namespace bolnica_back.Services
{
    public class SurveyService
    {
        private readonly ISurveyRepository surveyRepository;
        private readonly UserService userService;

        public SurveyService(ISurveyRepository surveyRepository, UserService userService)
        {
            this.surveyRepository = surveyRepository;
            this.userService = userService;
        }

        public List<Survey> GetAll()
        {
            List<Survey> surveys = new List<Survey>();
            foreach(Survey s in surveyRepository.GetAll())
            {
                s.User = userService.FindUserById(s.UserId);
                surveys.Add(s);
            }
            return surveys;
        }

        public Survey FindById(long id)
        {
            return surveyRepository.FindById(id);
        }

        public void Delete(long id)
        {
            surveyRepository.Delete(FindById(id));
        }

        public void PublishSurvey(long id)
        {
            surveyRepository.PublishSurvey(id);
        }

        public void UnPublishSurvey(long id)
        {
            surveyRepository.UnPublishSurvey(id);
        }

        public bool IsTimeForSurvery(long userId)
        {
            Survey lastSurvey = GetLastSurveyOfUser(userId);
            DateTime controlTime = DateTime.Now.AddDays(-15);

            return lastSurvey.CreationDate <= controlTime;
        }

        public void Create(Survey survey)
        {
            surveyRepository.Add(survey);
        }

        public List<SurveyDTO> GetAllPublishedSurveys()
        {
            List<SurveyDTO> surveys = new List<SurveyDTO>();
            foreach(Survey s in GetAll())
            {
                SurveyDTO survey = new SurveyDTO(s);
                surveys.Add(survey);
            }
            return surveys;
        }

        private Survey GetLastSurveyOfUser(long userId)
        {
            List<Survey> surveys = GetAllSurveyOfUser(userId);
            surveys.Sort((a, b) => b.CreationDate.CompareTo(a.CreationDate));
            return surveys[0];
        }

        private List<Survey> GetAllSurveyOfUser(long userId)
        {
            List<Survey> surveys = new List<Survey>();
            foreach (Survey s in surveyRepository.GetAll())
                if (s.UserId == userId)
                    surveys.Add(s);
            return surveys;
        }
    }
}
