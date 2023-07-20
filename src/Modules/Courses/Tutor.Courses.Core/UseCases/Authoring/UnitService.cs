using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Authoring;

public class UnitService : CrudService<KnowledgeUnitDto, KnowledgeUnit>, IUnitService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public UnitService(IMapper mapper, ICrudRepository<KnowledgeUnit> unitRepository,
        IOwnedCourseRepository ownedCourseRepository, ICoursesUnitOfWork unitOfWork) : base(unitRepository, unitOfWork, mapper)
    {
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<KnowledgeUnitDto> Create(KnowledgeUnitDto unit, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(unit.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Create(unit);
    }

    public Result<KnowledgeUnitDto> Update(KnowledgeUnitDto unit, int instructorId)
    {
        if (!_ownedCourseRepository.IsUnitOwner(unit.Id, instructorId))
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