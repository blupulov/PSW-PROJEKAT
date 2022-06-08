using bolnica_back.DTOs;
using bolnica_back.Interfaces;
using bolnica_back.Model;
using bolnica_back.Repositories;
using bolnica_back.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bolnica_backAppTest.Integration
{
    public class SurveyServiceTest
    {
        [Fact]
        public void Get_all()
        {
            SurveyService surveyService = CreateSurveyService();

            List<Survey> surveys = surveyService.GetAll();

            Assert.NotNull(surveys);
        }

        [Fact]
        public void Get_by_id()
        {
            SurveyService surveyService = CreateSurveyService();

            Survey survey = surveyService.FindById(1);

            Assert.NotNull(survey);
        }

        [Fact]
        public void Is_time_for_survey()
        {
            SurveyService surveyService = CreateSurveyService();

            bool isTime = surveyService.IsTimeForSurvery(7);

            Assert.True(isTime);
        }

        [Fact]
        public void Get_all_published_surveys()
        {
            SurveyService surveyService = CreateSurveyService();

            List<SurveyDTO> surveys = surveyService.GetAllPublishedSurveys();

            Assert.NotNull(surveys);
        }


        private SurveyService CreateSurveyService()
        {
            ISurveyRepository repo = new SurveyRepository(new ApplicationDbContext());

            return new SurveyService(repo, CreateUserService());
        }

        private UserService CreateUserService()
        {
            IUserRepository repo = new UserRepository(new ApplicationDbContext());
            return new UserService(repo, CreatePenaltyPointService());
        }

        private PenaltyPointService CreatePenaltyPointService()
        {
            IPenaltyPointRepository repo = new PenaltyPointRepository(new ApplicationDbContext());
            return new PenaltyPointService(repo);
        }
    }
}
