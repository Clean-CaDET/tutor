using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class InstructionService : IInstructionService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InstructionService(IKnowledgeComponentRepository kcRepository, IOwnedCourseRepository ownedCourseRepository, IUnitOfWork unitOfWork)
    {
        _kcRepository = kcRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<List<InstructionalItem>> GetForKc(int kcId, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(kcId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return kc.GetOrderedInstructionalItems();
    }

    public Result<InstructionalItem> Create(InstructionalItem instruction, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(instruction.KnowledgeComponentId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        kc.InstructionalItems.Add(instruction);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return instruction;
    }

    public Result<InstructionalItem> Update(InstructionalItem instruction, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(instruction.KnowledgeComponentId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        kc.RemoveInstructionalItem(instruction.Id);
        kc.InstructionalItems.Add(instruction);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return instruction;
    }

    public Result<List<InstructionalItem>> UpdateOrdering(int kcId, List<InstructionalItem> items, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(kcId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        foreach (var instruction in kc.InstructionalItems)
        {
            var relatedItem = items.FirstOrDefault(i => i.Id == instruction.Id);
            if(relatedItem == null) return Result.Fail(FailureCode.NotFound);
            instruction.Order = relatedItem.Order;
        }

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(kc.GetOrderedInstructionalItems());
    }

    public Result Delete(int id, int kcId, int instructorId)
    {
        var kc = _kcRepository.GetKnowledgeComponentWithInstruction(kcId);

        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        kc.RemoveInstructionalItem(id);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}