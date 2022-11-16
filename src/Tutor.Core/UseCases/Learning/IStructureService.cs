using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public interface IStructureService
    {
        Result<KnowledgeUnit> GetUnit(int unitId, int learnerId);

        Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId);
        Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId);
        Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId);
    }
}
