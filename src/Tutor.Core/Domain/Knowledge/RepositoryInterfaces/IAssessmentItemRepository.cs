using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.Domain.Knowledge.RepositoryInterfaces;

public interface IAssessmentItemRepository: ICrudRepository<AssessmentItem>
{
    AssessmentItem GetDerivedAssessmentItem(int assessmentItemId);
    List<AssessmentItem> GetDerivedAssessmentItemsForKc(int kcId);
}