using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases.Authoring;

public class KnowledgeComponentService : CrudService<KnowledgeComponentDto, KnowledgeComponent>, IKnowledgeComponentService
{
    private readonly IAccessService _accessService;

    public KnowledgeComponentService(IMapper mapper, IKnowledgeComponentRepository kcRepository, IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork) : base(kcRepository, unitOfWork, mapper)
    {
        _accessService = accessService;
    }

    public Result<KnowledgeComponentDto> Get(int id, int instructorId)
    {
        if(!_accessService.IsKcOwner(id, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Get(id);
    }

    public Result<KnowledgeComponentDto> Create(KnowledgeComponentDto kc, int instructorId)
    {
        if (!_accessService.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(kc);
    }

    public Result<KnowledgeComponentDto> Update(KnowledgeComponentDto kc, int instructorId)
    {
        if (!_accessService.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Update(kc);
    }

    public Result Delete(int id, int instructorId)
    {
        if (!_accessService.IsKcOwner(id, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}