using bolnica_back.Interfaces;
using bolnica_back.Model;
using System;

namespace bolnica_back.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(ApplicationDbContext context) : base(context) { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public void PublishSurvey(long id)
        {
            Survey survey = FindById(id);
            survey.IsPublished = true;
            ApplicationDbContext.SaveChanges();
        }

        public void UnPublishSurvey(long id)
        {
            Survey survey = FindById(id);
            survey.IsPublished = false;
            ApplicationDbContext.SaveChanges();
        }
    }
}
