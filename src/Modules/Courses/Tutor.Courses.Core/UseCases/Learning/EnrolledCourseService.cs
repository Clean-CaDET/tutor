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

    public Result<CourseDto> GetWithAccessibleUnits(int courseId, int learnerId)
    {
        var course = _groupRepository.GetEnrolledCourse(courseId, learnerId);
        if (course == null) return Result.Fail(FailureCode.Forbidden);

        var accessibleEnrollments = GetAccessibleEnrollments(courseId, learnerId);

        return CreateDto(course, accessibleEnrollments);
    }

    private List<UnitEnrollment> GetAccessibleEnrollments(int courseId, int learnerId)
    {
        return _unitEnrollmentRepository
            .GetEnrolledUnits(courseId, learnerId)
            .Where(e => e.IsAccessible())
            .ToList();
    }

    private Result<CourseDto> CreateDto(Course course, List<UnitEnrollment> accessibleEnrollments)
    {
        var courseDto = MapToDto(course);
        courseDto.KnowledgeUnits = new List<KnowledgeUnitDto>(accessibleEnrollments.Count);
        foreach (var enrollment in accessibleEnrollments)
        {
            var unitDto = _mapper.Map<KnowledgeUnitDto>(enrollment.KnowledgeUnit);
            unitDto.BestBefore = enrollment.BestBefore;
            unitDto.EnrollmentStatus = enrollment.Status.ToString();
            courseDto.KnowledgeUnits.Add(unitDto);
        }
        return courseDto;
    }

    public bool HasAccessibleEnrollment(int unitId, int learnerId)
    {
        var enrollment = _unitEnrollmentRepository.Get(unitId, learnerId);
        return enrollment != null && enrollment.IsAccessible();
    }

    public Result<KnowledgeUnitDto> GetUnit(int unitId, int learnerId)
    {
        var enrollment = _unitEnrollmentRepository.Get(unitId, learnerId);
        if(enrollment == null || !enrollment.IsAccessible())
            return Result.Fail(FailureCode.Forbidden);

        return _mapper.Map<KnowledgeUnitDto>(enrollment.KnowledgeUnit);
    }
}