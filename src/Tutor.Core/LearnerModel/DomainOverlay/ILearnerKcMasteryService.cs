using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public interface ILearnerKcMasteryService
    {
        Result<List<Unit>> GetUnits();

        Result<Unit> GetUnit(int unitId, int learnerId);
        Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId);

        Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId);

        Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId);

        Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId);

        Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int knowledgeComponentId, int learnerId);

        Result LaunchSession(int knowledgeComponentId, int learnerId);

        Result TerminateSession(int knowledgeComponentId, int learnerId);
    }
}