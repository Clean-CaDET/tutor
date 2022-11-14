using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning;

public class StructureService : IStructureService
{
    private readonly IKcMasteryRepository _kcMasteryRepository;

    public StructureService(IKcMasteryRepository kcMasteryRepository)
    {
        _kcMasteryRepository = kcMasteryRepository;
    }

    public Result<List<KnowledgeUnit>> GetUnits(int learnerId)
    {
        return Result.Ok(_kcMasteryRepository.GetEnrolledUnits(learnerId));
    }

    public Result<KnowledgeUnit> GetUnit(int unitId, int learnerId)
    {
        var unit = _kcMasteryRepository.GetUnitWithKcs(unitId, learnerId);
        if (unit == null) return Result.Fail("Learner not enrolled in KC: " + unitId);

        return Result.Ok(unit);
    }

    public Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId)
    {
        return Result.Ok(_kcMasteryRepository.GetBasicKcMasteries(kcIds, learnerId));
    }
}