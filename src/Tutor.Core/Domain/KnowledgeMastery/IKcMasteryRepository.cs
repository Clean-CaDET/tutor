using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.Domain.KnowledgeMastery
{
    public interface IKcMasteryRepository
    {
        KnowledgeComponentMastery GetBasicKcMastery(int knowledgeComponentId, int learnerId);
        List<KnowledgeComponentMastery> GetBasicKcMasteries(List<int> kcIds, int learnerId);
        KnowledgeComponentMastery GetFullKcMastery(int knowledgeComponentId, int learnerId);
        KnowledgeComponentMastery GetKcMasteryForAssessmentItem(int assessmentItemId, int learnerId);
        void UpdateKcMastery(KnowledgeComponentMastery kcMastery);

        AssessmentItem GetDerivedAssessmentItem(int assessmentItemId);
    }
}