using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases.Authoring;

public class AssessmentService : CrudService<AssessmentItemDto, AssessmentItem>, IAssessmentService
{
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IAccessService _accessService;

    public AssessmentService(IMapper mapper, IAssessmentItemRepository assessmentItemRepository, IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork) : base(assessmentItemRepository, unitOfWork, mapper)
    {
        _assessmentItemRepository = assessmentItemRepository;
        _accessService = accessService;
    }

    public Result<List<AssessmentItemDto>> GetByKc(int kcId, int instructorId)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return MapToDto(_assessmentItemRepository.GetDerivedAssessmentItemsForKc(kcId));
    }

    public Result<AssessmentItemDto> Create(AssessmentItemDto item, int instructorId)
    {
        if (!_accessService.IsKcOwner(item.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(item);
    }
    
    public Result<AssessmentItemDto> Update(AssessmentItemDto item, int instructorId)
    {
        if (!_accessService.IsKcOwner(item.KnowledgeComponentId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Update(item);
    }

    public Result<List<AssessmentItemDto>> UpdateOrdering(List<AssessmentItemDto> items, int instructorId)
    {
        var kcId = items.Select(i => i.KnowledgeComponentId).ToList();
        if (kcId.Count > 1 || !_accessService.IsKcOwner(kcId.First(), instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var updatedItems = items
            .Select(i => _assessmentItemRepository.Update(MapToDomain(i)))
            .OrderBy(a => a.Order)
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