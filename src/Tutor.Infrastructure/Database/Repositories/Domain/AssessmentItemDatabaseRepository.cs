using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class AssessmentItemDatabaseRepository : IAssessmentItemRepository
    {
        private readonly TutorContext _dbContext;

        public AssessmentItemDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AssessmentItem GetDerivedAssessmentItem(int assessmentItemId)
        {
            return _dbContext.AssessmentItems
                .Where(ae => ae.Id == assessmentItemId)
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
        
        public List<AssessmentItem> GetAssessmentItemsByKnowledgeComponent(int id)
        {
            var query = _dbContext.AssessmentItems
                .Where(ae => ae.KnowledgeComponentId == id)
                .Include(ae => (ae as Mrq).Items)
                .Include(lo => (lo as ArrangeTask).Containers)
                .ThenInclude(c => c.Elements);
            return query.ToList();
        }
        
        public List<AssessmentItem> GetAssessmentItemsWithLearnerSubmissions(int knowledgeComponentId,
            int learnerId)
        {
            var query = _dbContext.AssessmentItems
                .Where(ae => ae.KnowledgeComponentId == knowledgeComponentId)
                .Include(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId));
            return query.ToList();
        }

        public Submission FindSubmissionWithMaxCorrectness(int assessmentItemId, int learnerId)
        {
            return _dbContext.Submissions.Where(sub => sub.AssessmentItemId == assessmentItemId && sub.LearnerId == learnerId)
                .OrderBy(sub => sub.CorrectnessLevel).LastOrDefault();
        }
    }
}