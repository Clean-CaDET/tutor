namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public interface IAssessmentItemSelector
{
    int SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed);
}