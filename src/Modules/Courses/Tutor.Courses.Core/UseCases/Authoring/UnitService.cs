using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Authoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Authoring;

public class UnitService : CrudService<KnowledgeUnitDto, KnowledgeUnit>, IUnitService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IUnitEnrollmentRepository _enrollmentRepository;

    public UnitService(IMapper mapper, ICrudRepository<KnowledgeUnit> unitRepository, IOwnedCourseRepository ownedCourseRepository,
        IUnitEnrollmentRepository enrollmentRepository, ICoursesUnitOfWork unitOfWork) : base(unitRepository, unitOfWork, mapper)
    {
        _ownedCourseRepository = ownedCourseRepository;
        _enrollmentRepository = enrollmentRepository;
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

    public Result<List<KnowledgeUnitDto>> GetUnitsForWeek(int courseId, int learnerId, DateTime weekEnd, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var enrollments = _enrollmentRepository.GetStartedInDateRange(learnerId, weekEnd.AddDays(-8), weekEnd);
        var units = enrollments.Select(ue => ue.KnowledgeUnit).Where(ku => ku.CourseId == courseId).ToList();
        return MapToDto(units);
    }
}