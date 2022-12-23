using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class CourseService : CrudService<Course>, ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICrudRepository<LearnerGroup> _groupRepository;

    public CourseService (ICourseRepository courseRepository, ICrudRepository<LearnerGroup> groupRepository) : base (courseRepository)
    {
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
    }

    public override Result<Course> Create(Course course)
    {
        // Warning: Unit of work
        var createdCourse = base.Create(course);
        _groupRepository.Create(new LearnerGroup("Group 1", createdCourse.Value));

        return createdCourse;
    }

    public Result<PagedResult<Course>> GetAll(bool includeArchived, int page, int pageSize)
    {
        return includeArchived ? _courseRepository.GetPaged(page, pageSize) : _courseRepository.GetActive(page, pageSize);
    }

    public Result<Course> Archive(int id, bool archive)
    {
        var course = _courseRepository.Get(id);
        if (course == null) return Result.Fail(FailureCode.NotFound);

        course.IsArchived = archive;
        _courseRepository.Update(course);
        return Result.Ok(course);
    }
}