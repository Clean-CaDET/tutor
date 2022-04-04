using System.Collections.Generic;
using Tutor.Core.DomainModel.InstructionalItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKcRepository
    {
        List<Unit> GetUnits();

        Unit GetUnit(int id, int learnerId);

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<InstructionalItem> GetInstructionalItems(int knowledgeComponentId);

        KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId);

        KnowledgeComponentMastery GetKnowledgeComponentMasteryByAssessmentItem(int learnerId, int assessmentItemId);

        void UpdateKcMastery(KnowledgeComponentMastery kcMastery);

        List<KnowledgeComponent> GetAllKnowledgeComponents();
    }
}