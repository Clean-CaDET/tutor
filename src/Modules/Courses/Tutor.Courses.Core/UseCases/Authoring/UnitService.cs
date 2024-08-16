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
    private readonly IUnitEnrollmentRepository _unitEnrollmentRepository;

    public UnitService(IMapper mapper, ICrudRepository<KnowledgeUnit> unitRepository, IOwnedCourseRepository ownedCourseRepository,
        IUnitEnrollmentRepository unitEnrollmentRepository, ICoursesUnitOfWork unitOfWork) : base(unitRepository, unitOfWork, mapper)
    {
        _ownedCourseRepository = ownedCourseRepository;
        _unitEnrollmentRepository = unitEnrollmentRepository;
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

    public Result<List<KnowledgeUnitDto>> GetUnitsStartedDuringWeekBeforeDate(int courseId, int learnerId, DateTime date, int instructorId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        List<UnitEnrollment> unitEnrollments = _unitEnrollmentRepository.GetEnrollmentsWithStartBetweenDates(learnerId, date.AddDays(-8), date);
        List<KnowledgeUnit> knowledgeUnits = unitEnrollments.Select(ue => ue.KnowledgeUnit).Where(ku => ku.CourseId == courseId).ToList();
        return MapToDto(knowledgeUnits);
    }
}