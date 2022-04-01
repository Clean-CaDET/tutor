using System.Collections.Generic;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKcRepository
    {
        List<Unit> GetUnits();

        Unit GetUnit(int id, int learnerId);

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<InstructionalEvent> GetInstructionalEvents(int knowledgeComponentId);

        KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId);

        KnowledgeComponentMastery GetKnowledgeComponentMasteryByAssessmentEvent(int learnerId, int assessmentEventId);

        void UpdateKcMastery(KnowledgeComponentMastery kcMastery);

        List<KnowledgeComponent> GetAllKnowledgeComponents();
    }
}