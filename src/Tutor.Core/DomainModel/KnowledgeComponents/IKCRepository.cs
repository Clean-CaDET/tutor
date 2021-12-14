using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCRepository
    {
        List<Unit> GetUnits();
        
        Unit GetUnit(int id);

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id);

        List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id);
    }
}