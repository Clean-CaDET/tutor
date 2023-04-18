using System.Collections.Generic;

namespace Tutor.Core.Domain.KnowledgeMastery;

public interface IKnowledgeMasteryRepository
{
    KnowledgeComponentMastery GetBare(int knowledgeComponentId, int learnerId);
    KnowledgeComponentMastery GetFull(int knowledgeComponentId, int learnerId);
    KnowledgeComponentMastery GetFullForAssessmentItem(int assessmentItemId, int learnerId);
    List<KnowledgeComponentMastery> GetAllBareForLearnerAndKcs(List<int> kcIds, int learnerId);
    void Update(KnowledgeComponentMastery kcMastery);
    void Create(KnowledgeComponentMastery kcMastery);
}