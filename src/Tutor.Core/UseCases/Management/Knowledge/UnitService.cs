using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class UnitService : CrudService<KnowledgeUnit>, IUnitService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public UnitService(IUnitRepository unitRepository, IOwnedCourseRepository ownedCourseRepository, IUnitOfWork unitOfWork) : base(unitRepository, unitOfWork)
    {
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<KnowledgeUnit> Create(KnowledgeUnit unit, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(unit.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(unit);
    }

    public Result<KnowledgeUnit> Update(KnowledgeUnit unit, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(unit.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Update(unit);
    }

    public Result Delete(int id, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(id, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}