using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.KnowledgeMastery
{
    public interface IKcMasteryRepository
    {
        List<KnowledgeUnit> GetEnrolledUnits(int learnerId);
        KnowledgeUnit GetUnitWithKcs(int unitId, int learnerId);

        KnowledgeComponentMastery GetBasicKcMastery(int knowledgeComponentId, int learnerId);
        List<KnowledgeComponentMastery> GetBasicKcMasteries(List<int> kcIds, int learnerId);
        KnowledgeComponentMastery GetFullKcMastery(int knowledgeComponentId, int learnerId);
        KnowledgeComponentMastery GetKcMasteryForAssessmentItem(int assessmentItemId, int learnerId);
        void UpdateKcMastery(KnowledgeComponentMastery kcMastery);

        AssessmentItem GetDerivedAssessmentItem(int assessmentItemId);
    }
}