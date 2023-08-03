using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.Repositories;

public class AssessmentItemDatabaseRepository : CrudDatabaseRepository<AssessmentItem, KnowledgeComponentsContext>, IAssessmentItemRepository
{
    public AssessmentItemDatabaseRepository(KnowledgeComponentsContext dbContext): base(dbContext) {}
        
    public AssessmentItem? GetDerivedAssessmentItem(int assessmentItemId)
    {
        return DbContext.AssessmentItems
            .FirstOrDefault(ae => ae.Id == assessmentItemId);
    }
    
    public List<AssessmentItem> GetDerivedAssessmentItemsForKc(int kcId)
    {
        return DbContext.AssessmentItems
            .Where(ae => ae.KnowledgeComponentId == kcId)
            .ToList();
    }
}