using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public interface IKcMasteryService
    {
        Result<List<KnowledgeUnit>> GetUnits(int learnerId);

        Result<KnowledgeUnit> GetUnit(int unitId, int learnerId);
        
        Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId);

        Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId);

        Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId);

        Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId);

        Result<KcMasteryStatistics> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId);

        Result LaunchSession(int knowledgeComponentId, int learnerId);

        Result TerminateSession(int knowledgeComponentId, int learnerId);
    }
}