using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class AssessmentEventDatabaseRepository : IAssessmentEventRepository
    {
        private readonly TutorContext _dbContext;

        public AssessmentEventDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AssessmentEvent GetAssessmentEvent(int assessmentEventId)
        {
            return _dbContext.AssessmentEvents
                .Where(ae => ae.Id == assessmentEventId)
                .Include(ae => (ae as Mrq).Items)
                .Include(ae => (ae as ArrangeTask).Containers)
                .ThenInclude(c => c.Elements)
                .Include(ae => (ae as Challenge).FulfillmentStrategies)
                .ThenInclude(s => (s as BannedWordsChecker).Hint)
                .Include(ae => (ae as Challenge).FulfillmentStrategies)
                .ThenInclude(s => (s as RequiredWordsChecker).Hint)
                .Include(ae => (ae as Challenge).FulfillmentStrategies)
                .ThenInclude(s => (s as BasicMetricChecker).MetricRanges)
                .ThenInclude(r => r.Hint)
                .FirstOrDefault();
        }

        public void SaveSubmission(Submission submission)
        {
            _dbContext.Submissions.Attach(submission);
            _dbContext.SaveChanges();
        }

        public Submission FindSubmissionWithMaxCorrectness(Submission submission)
        {
            if (!_dbContext.Submissions.Any(sub =>
                sub.AssessmentEventId == submission.AssessmentEventId && sub.LearnerId == submission.LearnerId))
                return null;

            return _dbContext.Submissions.Where(sub =>
                    sub.AssessmentEventId == submission.AssessmentEventId && sub.LearnerId == submission.LearnerId)
                .ToList()
                .OrderBy(sub => sub.CorrectnessLevel).Last();
        }
    }
}