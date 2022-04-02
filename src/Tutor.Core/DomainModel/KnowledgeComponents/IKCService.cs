using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKcService
    {
        Result<List<Unit>> GetUnits();

        Result<Unit> GetUnit(int id, int learnerId);

        Result<KnowledgeComponent> GetKnowledgeComponentById(int id);

        Result<List<AssessmentEvent>> GetAssessmentEventsByKnowledgeComponent(int id);

        Result<List<InstructionalEvent>> GetInstructionalEventsByKnowledgeComponent(int knowledgeComponentId, int learnerId);
        
        Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId);

        Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int learnerId, int knowledgeComponentId);
    }
}