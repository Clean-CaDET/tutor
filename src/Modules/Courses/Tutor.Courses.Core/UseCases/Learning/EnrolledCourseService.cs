using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Internal;
using Tutor.Courses.API.Public.Learning;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Learning;

public class EnrolledCourseService : BaseService<CourseDto, Course>, IEnrolledCourseService, IEnrollmentValidator
{
    private readonly IMapper _mapper;
    private readonly IUnitEnrollmentRepository _unitEnrollmentRepository;
    private readonly IGroupRepository _groupRepository;

    public EnrolledCourseService(IMapper mapper, IUnitEnrollmentRepository unitEnrollmentRepository, IGroupRepository groupRepository) : base(mapper)
    {
        _mapper = mapper;
        _unitEnrollmentRepository = unitEnrollmentRepository;
        _groupRepository = groupRepository;
    }

    public Result<PagedResult<CourseDto>> GetAll(int learnerId, int page, int pageSize)
    {
        var result = _groupRepository.GetEnrolledCourses(learnerId, page, pageSize);
        return MapToDto(result);
    }

    public Result<CourseDto> GetWithActiveUnits(int courseId, int learnerId)
    {
        var course = _groupRepository.GetEnrolledCourse(courseId, learnerId);
        if (course == null) return Result.Fail(FailureCode.Forbidden);

        var allEnrollments = _unitEnrollmentRepository.GetEnrolledUnits(courseId, learnerId);
        var activeUnits = allEnrollments
            .Where(e => e.IsActive())
            .Select(e => e.KnowledgeUnit).ToList();
        course.KnowledgeUnits = activeUnits;

        return MapToDto(course);
    }

    public bool HasActiveEnrollment(int unitId, int learnerId)
    {
        var enrollment = _unitEnrollmentRepository.GetEnrollment(unitId, learnerId);
        return enrollment != null && enrollment.IsActive();
    }

    public Result<KnowledgeUnitDto> GetUnit(int unitId, int learnerId)
    {
        var enrollment = _unitEnrollmentRepository.GetEnrollment(unitId, learnerId);
        if(enrollment == null || !enrollment.IsActive())
            return Result.Fail(FailureCode.Forbidden);

        return _mapper.Map<KnowledgeUnitDto>(enrollment.KnowledgeUnit);
    }
}