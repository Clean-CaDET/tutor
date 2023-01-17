using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class AssessmentService : IAssessmentService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IAssessmentItemRepository _assessmentItemRepository;

    public AssessmentService(IAssessmentItemRepository assessmentItemRepository, IOwnedCourseRepository ownedCourseRepository)
    {
        _assessmentItemRepository = assessmentItemRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<AssessmentItem>> GetForKc(int kcId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return _assessmentItemRepository.GetDerivedAssessmentItemsForKc(kcId);
    }

    /*public Result<InstructionalItem> Create(InstructionalItem instruction, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(instruction.KnowledgeComponentId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        kc.InstructionalItems.Add(instruction);
        _kcRepository.Update(kc);

        return instruction;
    }

    public Result<InstructionalItem> Update(InstructionalItem instruction, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(instruction.KnowledgeComponentId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        kc.RemoveInstructionalItem(instruction.Id);
        kc.InstructionalItems.Add(instruction);
        _kcRepository.Update(kc);

        return instruction;
    }*/

    public Result<List<AssessmentItem>> UpdateOrdering(int kcId, List<AssessmentItem> items, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        foreach (var assessmentItem in items)
        {
            //UoW violation
            _assessmentItemRepository.Update(assessmentItem);
        }

        return Result.Ok(items);
    }

    /*public Result Delete(int id, int kcId, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(kcId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        kc.RemoveInstructionalItem(id);
        _kcRepository.Update(kc);

        return Result.Ok();
    }*/
}