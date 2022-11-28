using System.Collections.Generic;

namespace Tutor.Core.Domain.KnowledgeMastery
{
    public interface IKnowledgeMasteryRepository
    {
        KnowledgeComponentMastery GetBareKcMastery(int knowledgeComponentId, int learnerId);
        List<KnowledgeComponentMastery> GetBasicKcMasteries(List<int> kcIds, int learnerId);
        KnowledgeComponentMastery GetFullKcMastery(int knowledgeComponentId, int learnerId);
        KnowledgeComponentMastery GetKcMasteryForAssessmentItem(int assessmentItemId, int learnerId);
        void UpdateKcMastery(KnowledgeComponentMastery kcMastery);
    }
}