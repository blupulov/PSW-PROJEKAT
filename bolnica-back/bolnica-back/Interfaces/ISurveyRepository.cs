using bolnica_back.Model;

namespace bolnica_back.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        void PublishSurvey(long id);
        void UnPublishSurvey(long id);
    }
}
