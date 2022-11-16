using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning;

public class StructureService : IStructureService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IKnowledgeStructureRepository _knowledgeStructureRepository;

    public StructureService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IEnrollmentRepository enrollmentRepository, IKnowledgeStructureRepository knowledgeStructureRepository)
    {
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _enrollmentRepository = enrollmentRepository;
        _knowledgeStructureRepository = knowledgeStructureRepository;
    }

    private bool HasActiveEnrollment(int unitId, int learnerId)
    {
        return _enrollmentRepository.LearnerHasActiveEnrollment(unitId, learnerId);
    }

    public Result<KnowledgeUnit> GetUnit(int unitId, int learnerId)
    {
        if(!HasActiveEnrollment(unitId, learnerId)) return Result.Fail("Learner not enrolled in Unit: " + unitId);
        return Result.Ok(_knowledgeStructureRepository.GetUnitWithKcs(unitId));
    }

    public Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId)
    {
        return Result.Ok(_knowledgeMasteryRepository.GetBasicKcMasteries(kcIds, learnerId));
    }

    public Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _knowledgeMasteryRepository.GetBasicKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

        return Result.Ok(kcMastery.KnowledgeComponent);
    }

    public Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

        var result = kcMastery.RecordInstructionalItemSelection();
        if (result.IsFailed) return result.ToResult<List<InstructionalItem>>();

        _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);

        return Result.Ok(kcMastery.KnowledgeComponent.GetOrderedInstructionalItems());
    }
}