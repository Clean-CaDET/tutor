namespace Tutor.Core.Domain.Knowledge.AssessmentItems;

public interface IAssessmentItemRepository
{
    AssessmentItem GetDerivedAssessmentItem(int assessmentItemId);
}