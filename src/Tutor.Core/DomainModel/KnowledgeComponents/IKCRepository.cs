using System.Collections.Generic;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCRepository
    {
        List<Unit> GetUnits();
        
        Unit GetUnit(int id, int learnerId);

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id);

        KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId);
        
        void UpdateKCMastery(KnowledgeComponentMastery kcMastery);
        List<KnowledgeComponent> GetAllKnowledgeComponents();
    }
}