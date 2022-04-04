using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKcService
    {
        Result<List<Unit>> GetUnits();

        Result<Unit> GetUnit(int id, int learnerId);

        Result<KnowledgeComponent> GetKnowledgeComponentById(int id);

        Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId);

        Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId);

        Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int learnerId, int knowledgeComponentId);

        Result LaunchSession(int learnerId, int knowledgeComponentId);

        Result TerminateSession(int learnerId, int knowledgeComponentId);
    }
}