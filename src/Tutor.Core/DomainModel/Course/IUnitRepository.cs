using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.Course
{
    public interface IUnitRepository
    {
        Unit GetUnit(int id);
        List<Unit> GetUnits();

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id);

        List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id);
    }
}