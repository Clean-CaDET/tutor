using System.Collections.Generic;
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

        public AssessmentEvent GetDerivedAssessmentEvent(int assessmentEventId)
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
                .ThenInclude(s => (s as BasicMetricChecker).Hint)
                .FirstOrDefault();
        }
        
        public List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id)
        {
            var query = _dbContext.AssessmentEvents
                .Where(ae => ae.KnowledgeComponentId == id)
                .Include(ae => (ae as Mrq).Items)
                .Include(lo => (lo as ArrangeTask).Containers)
                .ThenInclude(c => c.Elements);
            return query.ToList();
        }
        
        public List<AssessmentEvent> GetAssessmentEventsWithLearnerSubmissions(int knowledgeComponentId,
            int learnerId)
        {
            var query = _dbContext.AssessmentEvents
                .Where(ae => ae.KnowledgeComponentId == knowledgeComponentId)
                .Include(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId));
            return query.ToList();
        }

        public void SaveSubmission(Submission submission)
        {
            _dbContext.Submissions.Attach(submission);
            _dbContext.SaveChanges();
        }

        public Submission FindSubmissionWithMaxCorrectness(int assessmentEventId, int learnerId)
        {
            return _dbContext.Submissions.Where(sub => sub.AssessmentEventId == assessmentEventId && sub.LearnerId == learnerId)
                .OrderBy(sub => sub.CorrectnessLevel).LastOrDefault();
        }

        public int CountAssessmentEvents(int knowledgeComponentId)
        {
            return _dbContext.AssessmentEvents.Count(ae => ae.KnowledgeComponentId == knowledgeComponentId);
        }
    }
}