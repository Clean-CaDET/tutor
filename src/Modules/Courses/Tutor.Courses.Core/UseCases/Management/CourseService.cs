using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.Reflections;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.LearningTasks.API.Internal;

namespace Tutor.Courses.Core.UseCases.Management;

public class CourseService : BaseService<CourseDto, Course>, ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly ICourseOwnershipRepository _ownershipRepository;
    private readonly IUnitEnrollmentRepository _unitEnrollmentRepository;
    private readonly IReflectionRepository _reflectionRepository;
    private readonly IKnowledgeComponentCloner _kcCloner;
    private readonly ILearningTaskCloner _taskCloner;

    public CourseService(IMapper mapper, ICourseRepository courseRepository, ICoursesUnitOfWork unitOfWork,
        ICourseOwnershipRepository ownershipRepository, IUnitEnrollmentRepository unitEnrollmentRepository,
        IReflectionRepository reflectionRepository, IKnowledgeComponentCloner kcCloner, ILearningTaskCloner taskCloner) : base(mapper)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _ownershipRepository = ownershipRepository;
        _unitEnrollmentRepository = unitEnrollmentRepository;
        _reflectionRepository = reflectionRepository;
        _kcCloner = kcCloner;
        _taskCloner = taskCloner;
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

    public virtual Result<CourseDto> Update(CourseDto course)
    {
        var updatedCourse = _courseRepository.Update(MapToDomain(course));

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

    public Result<CourseDto> Clone(int courseId, CourseDto newCourse)
    {
        _unitOfWork.BeginTransaction();

        var result = CloneCourse(courseId, MapToDomain(newCourse));
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }
        _unitOfWork.Commit();

        return result;
    }

    private Result<CourseDto> CloneCourse(int courseId, Course newCourse)
    {
        var existingCourse = _courseRepository.GetWithUnits(courseId);
        if (existingCourse == null) return Result.Fail(FailureCode.NotFound);

        var clonedCourse = _courseRepository.Create(existingCourse.Clone(newCourse));

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        if (clonedCourse.KnowledgeUnits?.Count > 0 && existingCourse.KnowledgeUnits?.Count > 0)
        {
            var unitIdPairs = PairOldAndClonedUnits(existingCourse.KnowledgeUnits, clonedCourse.KnowledgeUnits);
            _kcCloner.CloneMany(unitIdPairs);
            _taskCloner.CloneMany(unitIdPairs);
            CloneReflections(unitIdPairs);
        }
        CloneOwnerships(clonedCourse, existingCourse.Id);

        result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(clonedCourse);
    }

    private static List<Tuple<int, int>> PairOldAndClonedUnits(List<KnowledgeUnit> existingUnits, List<KnowledgeUnit> clonedUnits)
    {
        var unitIdPairs = new List<Tuple<int, int>>();
        existingUnits.ForEach(existingUnit =>
        {
            var clonedUnit = clonedUnits.Find(c => c.Code == existingUnit.Code);
            if (clonedUnit == null)
                throw new InvalidOperationException("Unit with code " + existingUnit.Code + " was not cloned");
            unitIdPairs.Add(new Tuple<int, int>(existingUnit.Id, clonedUnit.Id));
        });
        return unitIdPairs;
    }

    private void CloneOwnerships(Course course, int clonedCourseId)
    {
        var owners = _ownershipRepository.GetOwnerIds(clonedCourseId);
        owners.ForEach(o => _ownershipRepository.Create(new CourseOwnership(course, o)));
    }

    private void CloneReflections(List<Tuple<int, int>> unitIdPairs)
    {
        var oldReflections = _reflectionRepository.GetByUnitsWithQuestions(unitIdPairs.Select(u => u.Item1).ToArray());

        var clonedReflections = oldReflections
            .Select(r => r.Clone(unitIdPairs.Find(pair => pair.Item1 == r.UnitId)!.Item2))
            .ToList();

        _reflectionRepository.BulkCreate(clonedReflections);
    }
}