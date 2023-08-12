using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IAssessmentItemRepository : ICrudRepository<AssessmentItem>
{
    AssessmentItem? GetDerivedAssessmentItem(int assessmentItemId);
    List<AssessmentItem> GetDerivedAssessmentItemsForKc(int kcId);
}