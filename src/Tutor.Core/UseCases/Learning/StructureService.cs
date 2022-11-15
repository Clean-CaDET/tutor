using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning;

public class StructureService : IStructureService
{
    private readonly IKcMasteryRepository _kcMasteryRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IKnowledgeRepository _knowledgeRepository;

    public StructureService(IKcMasteryRepository kcMasteryRepository, IGroupRepository groupRepository, IKnowledgeRepository knowledgeRepository)
    {
        _kcMasteryRepository = kcMasteryRepository;
        _groupRepository = groupRepository;
        _knowledgeRepository = knowledgeRepository;
    }

    private bool HasActiveEnrollment(int unitId, int learnerId)
    {
        return _groupRepository.LearnerHasActiveEnrollment(unitId, learnerId);
    }

    public Result<List<KnowledgeUnit>> GetUnits(int courseId, int learnerId)
    {
        return Result.Ok(_groupRepository.GetEnrolledAndActiveUnits(courseId, learnerId));
    }

    public Result<KnowledgeUnit> GetUnit(int unitId, int learnerId)
    {
        if(!HasActiveEnrollment(unitId, learnerId)) return Result.Fail("Learner not enrolled in Unit: " + unitId);
        return Result.Ok(_knowledgeRepository.GetUnitWithKcs(unitId));
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