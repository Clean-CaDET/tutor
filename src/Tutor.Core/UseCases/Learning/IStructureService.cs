using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public interface IStructureService
    {
        Result<List<KnowledgeUnit>> GetUnits(int learnerId);

        Result<KnowledgeUnit> GetUnit(int unitId, int learnerId);

        Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId);
    }
}
