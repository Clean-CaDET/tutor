using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge
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
    }
}
