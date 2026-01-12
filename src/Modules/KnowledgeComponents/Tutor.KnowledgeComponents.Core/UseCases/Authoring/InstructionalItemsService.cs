using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases.Authoring;

public class InstructionalItemsService : CrudService<InstructionalItemDto, InstructionalItem>, IInstructionalItemsService
{
    private readonly IAccessService _accessService;
    private readonly IInstructionalItemRepository _instructionRepository;
    private readonly IKnowledgeComponentRepository _kcRepository;

    public InstructionalItemsService(IMapper mapper, IInstructionalItemRepository instructionRepository,
        IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork,
        IKnowledgeComponentRepository kcRepository) : base(instructionRepository, unitOfWork, mapper)
    {
        _instructionRepository = instructionRepository;
        _accessService = accessService;
        _kcRepository = kcRepository;
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

        MarkKcIndexingPartial(instruction.KnowledgeComponentId);
        return Create(instruction);
    }

    public Result<InstructionalItemDto> Update(InstructionalItemDto instruction, int instructorId)
    {
        if (!_accessService.IsKcOwner(instruction.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        MarkKcIndexingPartial(instruction.KnowledgeComponentId);
        return Update(instruction);
    }

    public Result<List<InstructionalItemDto>> UpdateOrdering(List<InstructionalItemDto> items, int instructorId)
    {
        var kcIds = items.Select(i => i.KnowledgeComponentId).Distinct().ToList();
        if (kcIds.Count > 1 || !_accessService.IsKcOwner(kcIds.First(), instructorId))
            return Result.Fail(FailureCode.Forbidden);

        MarkKcIndexingPartial(kcIds.First());

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

        MarkKcIndexingPartial(kcId);
        return Delete(id);
    }

    private void MarkKcIndexingPartial(int kcId)
    {
        var kc = _kcRepository.Get(kcId);
        if (kc != null && kc.IndexingDegree == KcIndexingDegree.Full)
        {
            kc.IndexingDegree = KcIndexingDegree.Partial;
        }
    }
}