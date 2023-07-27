using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Authoring;

namespace Tutor.Courses.Core.UseCases.Management;

public class CourseService : BaseService<CourseDto, Course>, ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly ICourseOwnershipRepository _ownershipRepository;
    private readonly IUnitEnrollmentRepository _unitEnrollmentRepository;
    private readonly IKnowledgeComponentService _kcService;

    public CourseService(IMapper mapper, ICourseRepository courseRepository, ICoursesUnitOfWork unitOfWork, ICourseOwnershipRepository ownershipRepository, IUnitEnrollmentRepository unitEnrollmentRepository, IKnowledgeComponentService kcService) : base(mapper)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _ownershipRepository = ownershipRepository;
        _unitEnrollmentRepository = unitEnrollmentRepository;
        _kcService = kcService;
    }

    public Result<PagedResult<CourseDto>> GetAll(int page, int pageSize)
    {
        return MapToDto(_courseRepository.GetPagedSortedByDate(page, pageSize));
    }

    public virtual Result<CourseDto> Create(CourseDto course)
    {
        var createdCourse = _courseRepository.Create(MapToDomain(course));

        var result = _unitOfWork.Save();
        return result.IsFailed ? result : MapToDto(createdCourse);
    }

    public virtual Result<CourseDto> Update(CourseDto entity)
    {
        var updatedCourse = _courseRepository.Update(MapToDomain(entity));

        var result = _unitOfWork.Save();
        return result.IsFailed ? result : MapToDto(updatedCourse);
    }

    public Result<CourseDto> Archive(int id, bool archive)
    {
        var course = _courseRepository.Get(id);
        if (course == null) return Result.Fail(FailureCode.NotFound);

        course.IsArchived = archive;
        if (course.IsArchived)
        {
            DeactivateEnrollments(course.Id);
        }

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(course);
    }

    private void DeactivateEnrollments(int courseId)
    {
        var enrollments = _unitEnrollmentRepository.GetActiveEnrollmentsForCourse(courseId);
        enrollments.ForEach(e =>
        {
            e.Status = EnrollmentStatus.Deactivated;
            _unitEnrollmentRepository.Update(e);
        });
    }

    public Result Delete(int id)
    {
        var course = _courseRepository.GetWithUnits(id);
        if (course == null) return Result.Fail(FailureCode.NotFound);

        if (course.KnowledgeUnits?.Count > 0)
        {
            return Result.Fail(FailureCode.Forbidden);
        }

        _courseRepository.Delete(course);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }

    public Result<CourseDto> Clone(int courseId)
    {
        _unitOfWork.BeginTransaction();

        var result = CloneCourse(courseId);
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }
        _unitOfWork.Commit();

        return result;
    }

    private Result<CourseDto> CloneCourse(int courseId)
    {
        var existingCourse = _courseRepository.GetWithUnits(courseId);

        var clonedCourse = _courseRepository.Create(existingCourse.Clone());

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        if (clonedCourse.KnowledgeUnits?.Count > 0)
        {
            CloneKcs(existingCourse.KnowledgeUnits, clonedCourse.KnowledgeUnits);
        }
        CloneOwnerships(clonedCourse, existingCourse.Id);

        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(clonedCourse);
    }

    private Result CloneKcs(List<KnowledgeUnit> existingUnits, List<KnowledgeUnit> clonedUnits)
    {
        var unitIdPairs = new List<Tuple<int, int>>();
        existingUnits.ForEach(existingUnit =>
        {
            // TODO: Add unique constraint for unit and KC codes.
            var clonedUnitId = clonedUnits.Find(c => c.Code == existingUnit.Code).Id;
            unitIdPairs.Add(new Tuple<int, int>(existingUnit.Id, clonedUnitId));
        });

        return _kcService.CloneMany(unitIdPairs);
    }

    private void CloneOwnerships(Course course, int clonedCourseId)
    {
        var owners = _ownershipRepository.GetOwnerIds(clonedCourseId);
        owners.ForEach(o => _ownershipRepository.Create(new CourseOwnership(course, o)));
    }
}