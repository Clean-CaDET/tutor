using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class AssessmentItemDatabaseRepository : IAssessmentItemRepository
{
    private readonly TutorContext _dbContext;

    public AssessmentItemDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public AssessmentItem GetDerivedAssessmentItem(int assessmentItemId)
    {
        var query = _dbContext.AssessmentItems
            .Where(ae => ae.Id == assessmentItemId);

        return IncludeDerivedFields(query).FirstOrDefault();
    }
    
    public List<AssessmentItem> GetDerivedAssessmentItemsForKc(int kcId)
    {
        var query = _dbContext.AssessmentItems
            .Where(ae => ae.KnowledgeComponentId == kcId);

        return IncludeDerivedFields(query).ToList();
    }

    private static IIncludableQueryable<AssessmentItem, ChallengeHint> IncludeDerivedFields(IQueryable<AssessmentItem> query)
    {
        return query
            .Include(ae => (ae as Mrq).Items)
            .Include(ae => (ae as ArrangeTask).Containers)
            .ThenInclude(c => c.Elements)
            .Include(ae => (ae as Challenge).FulfillmentStrategies)
            .ThenInclude(s => (s as BannedWordsChecker).Hint)
            .Include(ae => (ae as Challenge).FulfillmentStrategies)
            .ThenInclude(s => (s as RequiredWordsChecker).Hint)
            .Include(ae => (ae as Challenge).FulfillmentStrategies)
            .ThenInclude(s => (s as BasicMetricChecker).Hint);
    }
}