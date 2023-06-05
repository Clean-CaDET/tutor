using AutoMapper;
using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Courses;

public class CourseService : CrudService<Course>, ICourseService
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly ICrudRepository<LearnerGroup> _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;

    public CourseService(IMapper mapper, ICourseRepository courseRepository, ICrudRepository<LearnerGroup> groupRepository, IUnitOfWork unitOfWork, IOwnedCourseRepository ownedCourseRepository, IEnrollmentRepository enrollmentRepository) : base(courseRepository, unitOfWork)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<Course> CreateWithGroup(Course course)
    {
        // Creates the course as well through association
        _groupRepository.Create(new LearnerGroup("Group 1", course));

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return course;
    }

    public Result<Course> Clone(int courseId, Course course)
    {
        UnitOfWork.BeginTransaction();

        var result = CloneCourse(course, courseId);
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();

        return course;
    }

    private Result<Course> CloneCourse(Course course, int courseId)
    {
        var fullCourse = _courseRepository.GetFullCourse(courseId);
        _mapper.Map(fullCourse.KnowledgeUnits, course.KnowledgeUnits);

        var courseResult = CreateWithGroup(course);
        if (courseResult.IsFailed) return courseResult;

        LinkKcParents(course.KnowledgeUnits.SelectMany(u => u.KnowledgeComponents).ToList(),
            fullCourse.KnowledgeUnits.SelectMany(u => u.KnowledgeComponents).ToList());
        CreateOwnerships(course, fullCourse.Id);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return courseResult;
    }

    private void CreateOwnerships(Course course, int fullCourseId)
    {
        var owners = _ownedCourseRepository.GetOwners(fullCourseId);
        owners.ForEach(o =>
        {
            _ownedCourseRepository.CreateCourseOwnership(new CourseOwnership(course, o.Id));
        });
    }

    private static void LinkKcParents(List<KnowledgeComponent> clonedKcs, List<KnowledgeComponent> oldKcs)
    {
        foreach (var oldKc in oldKcs)
        {
            if(oldKc.ParentId == null || oldKc.ParentId == 0) continue;
            
            var oldKcParent = oldKcs.Find(kc => kc.Id == oldKc.ParentId);
            var matchingKc = clonedKcs.Find(kc => kc.Code == oldKc.Code);
            if(oldKcParent == null || matchingKc == null) continue;

            matchingKc.ParentId = clonedKcs.Find(kc => kc.Code == oldKcParent.Code)?.Id;
        }
    }

    public Result<PagedResult<Course>> GetAll(int page, int pageSize)
    {
        return _courseRepository.GetPagedSortedByDate(page, pageSize);
    }

    public Result<Course> Archive(int id, bool archive)
    {
        var courseResult = Get(id);
        if (courseResult.IsFailed) return courseResult;

        var course = courseResult.Value;
        course.IsArchived = archive;

        if (course.IsArchived)
        {
            HideEnrollments(course.Id);
        }

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(course);
    }

    private void HideEnrollments(int courseId)
    {
        var enrollments = _enrollmentRepository.GetActiveEnrollmentsForCourse(courseId);
        enrollments.ForEach(e =>
        {
            e.Status = EnrollmentStatus.Hidden;
            _enrollmentRepository.Update(e);
        });
    }

    public override Result Delete(int id)
    {
        var entity = _courseRepository.GetFullCourse(id);
        if (entity is null) return Result.Fail(FailureCode.NotFound);

        if (entity.KnowledgeUnits.Count > 0)
        {
            return Result.Fail(FailureCode.Forbidden);
        }

        _courseRepository.Delete(entity);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}