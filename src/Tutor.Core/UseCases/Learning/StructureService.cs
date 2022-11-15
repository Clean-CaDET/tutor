using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
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


    public Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _kcMasteryRepository.GetBasicKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

        return Result.Ok(kcMastery.KnowledgeComponent);
    }

    public Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

        var result = kcMastery.RecordInstructionalItemSelection();
        if (result.IsFailed) return result.ToResult<List<InstructionalItem>>();

        _kcMasteryRepository.UpdateKcMastery(kcMastery);

        return Result.Ok(kcMastery.KnowledgeComponent.GetOrderedInstructionalItems());
    }
}