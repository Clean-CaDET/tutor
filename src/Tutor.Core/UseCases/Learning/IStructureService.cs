using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning;

public interface IStructureService
{
    Result<List<int>> GetMasteredUnitIds(int[] unitIds, int learnerId);
    Result<KnowledgeUnit> GetUnit(int unitId, int learnerId);
    Result<List<KnowledgeComponentMastery>> GetMasteries(int unitId, int learnerId);
    Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId);
    Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId);
}