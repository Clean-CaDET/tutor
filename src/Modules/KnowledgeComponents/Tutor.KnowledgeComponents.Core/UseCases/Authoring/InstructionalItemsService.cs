using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases.Authoring;

public class InstructionalItemsService : CrudService<InstructionalItemDto, InstructionalItem>, IInstructionalItemsService
{
    private readonly IAccessService _accessService;
    private readonly IInstructionalItemRepository _instructionRepository;

    public InstructionalItemsService(IMapper mapper, IInstructionalItemRepository instructionRepository, IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork): base(instructionRepository, unitOfWork, mapper)
    {
        _instructionRepository = instructionRepository;
        _accessService = accessService;
    }

    public Result<List<InstructionalItemDto>> GetByKc(int kcId, int instructorId)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var items = _instructionRepository.GetByKc(kcId);
        return MapToDto(items);
    }

    public Result<InstructionalItemDto> Create(InstructionalItemDto instruction, int instructorId)
    {
        if (!_accessService.IsKcOwner(instruction.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(instruction);
    }

    public Result<InstructionalItemDto> Update(InstructionalItemDto instruction, int instructorId)
    {
        if (!_accessService.IsKcOwner(instruction.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Update(instruction);
    }

    public Result<List<InstructionalItemDto>> UpdateOrdering(List<InstructionalItemDto> items, int instructorId)
    {
        var kcId = items.Select(i => i.KnowledgeComponentId).Distinct().ToList();
        if (kcId.Count > 1 || !_accessService.IsKcOwner(kcId.First(), instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var updatedItems = items
            .Select(i => _instructionRepository.Update(MapToDomain(i)))
            .OrderBy(i => i.Order)
            .ToList();

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(updatedItems);
    }

    public Result Delete(int id, int kcId, int instructorId)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}