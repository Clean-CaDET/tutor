using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class AssessmentEventDatabaseRepository : IAssessmentEventRepository
    {
        private readonly TutorContext _dbContext;

        public AssessmentEventDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AssessmentEvent GetAssessmentEvent(int id)
        {
            return _dbContext.AssessmentEvents.FirstOrDefault(ae => ae.Id == id);
        }

        public void SaveSubmission(Submission submission)
        {
            _dbContext.Submissions.Attach(submission);
            _dbContext.SaveChanges();
        }
    }
}
