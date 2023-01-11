using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class KnowledgeComponentService : CrudService<KnowledgeComponent>, IKnowledgeComponentService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public KnowledgeComponentService(IKnowledgeComponentRepository kcRepository, IOwnedCourseRepository ownedCourseRepository) : base(kcRepository)
    {
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<KnowledgeComponent> Get(int id, int instructorId)
    {
        var kc = Get(id);
        if(!_ownedCourseRepository.IsUnitOwner(kc.Value.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return kc;
    }

    public Result<KnowledgeComponent> Create(KnowledgeComponent kc, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(kc);
    }

    public Result<KnowledgeComponent> Update(KnowledgeComponent kc, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(kc.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Update(kc);
    }

    public Result Delete(int id, int instructorId)
    {
        var kc = Get(id);
        
        if (!_ownedCourseRepository.IsUnitOwner(kc.Value.KnowledgeUnitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}