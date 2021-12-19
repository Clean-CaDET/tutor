using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKCRepository
    {
        List<Unit> GetUnits();
        
        Unit GetUnit(int id);

        KnowledgeComponent GetKnowledgeComponent(int id);

        List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id);

        List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id);
        
        KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId);
        
        void UpdateKCMastery(int kcId, double mastery);
    }
}