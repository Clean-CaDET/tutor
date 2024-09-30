namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

public interface IKnowledgeMasteryRepository
{
    KnowledgeComponentMastery? GetBare(int knowledgeComponentId, int learnerId);
    KnowledgeComponentMastery? GetFull(int knowledgeComponentId, int learnerId);
    KnowledgeComponentMastery? GetFullByAssessmentItem(int assessmentItemId, int learnerId);
    List<KnowledgeComponentMastery> GetBareByKcs(List<int> kcIds, int learnerId);
    void Update(KnowledgeComponentMastery kcMastery);
    void Create(KnowledgeComponentMastery kcMastery);
}