using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
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