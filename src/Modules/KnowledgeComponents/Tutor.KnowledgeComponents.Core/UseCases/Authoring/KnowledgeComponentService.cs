using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases.Authoring;

public class KnowledgeComponentService : CrudService<KnowledgeComponentDto, KnowledgeComponent>, IKnowledgeComponentService, IKnowledgeComponentCloner
{
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IAccessService _accessService;

    public KnowledgeComponentService(IMapper mapper, IKnowledgeComponentRepository kcRepository, IAccessService accessService, IKnowledgeComponentsUnitOfWork unitOfWork) : base(kcRepository, unitOfWork, mapper)
    {
        _kcRepository = kcRepository;
        _accessService = accessService;
    }
    
    public Result<List<KnowledgeComponentDto>> GetByUnit(int unitId, int instructorId)
    {
        if(!_accessService.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var result = _kcRepository.GetByUnit(unitId);
        return MapToDto(result);
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

    public Result CloneMany(List<Tuple<int, int>> unitIdPairs)
    {
        var oldKcs = _kcRepository.GetByUnitsWithItems(unitIdPairs.Select(u => u.Item1).ToList());

        UnitOfWork.BeginTransaction();
        
        var result = CloneKcs(oldKcs, unitIdPairs);

        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();

        return result;
    }

    private Result CloneKcs(List<KnowledgeComponent> oldKcs, List<Tuple<int, int>> unitIdPairs)
    {
        var clonedKcs = oldKcs
            .Select(kc => kc.Clone(
                unitIdPairs.Find(pair => pair.Item1 == kc.KnowledgeUnitId)!.Item2))
            .ToList();

        clonedKcs = _kcRepository.BulkCreate(clonedKcs);
        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        foreach (var pair in unitIdPairs)
        {
            LinkKcParents(
                clonedKcs.FindAll(kc => kc.KnowledgeUnitId == pair.Item2),
                oldKcs.FindAll(kc => kc.KnowledgeUnitId == pair.Item1)
            );
        }

        return UnitOfWork.Save();
    }

    private static void LinkKcParents(List<KnowledgeComponent> clonedKcs, List<KnowledgeComponent> oldKcs)
    {
        foreach (var oldKc in oldKcs)
        {
            if (oldKc.ParentId == null || oldKc.ParentId == 0) continue;

            var oldKcParent = oldKcs.Find(kc => kc.Id == oldKc.ParentId);
            var matchingKc = clonedKcs.Find(kc => kc.Code == oldKc.Code);
            if (oldKcParent == null || matchingKc == null) continue;

            matchingKc.ParentId = clonedKcs.Find(kc => kc.Code == oldKcParent.Code)?.Id;
        }
    }
}