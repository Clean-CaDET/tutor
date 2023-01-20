using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class CourseService : CrudService<Course>, ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ICrudRepository<LearnerGroup> _groupRepository;

    public CourseService(ICourseRepository courseRepository, ICrudRepository<LearnerGroup> groupRepository, IUnitOfWork unitOfWork) : base(courseRepository, unitOfWork)
    {
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
    }

    public override Result<Course> Create(Course course)
    {
        // If object has navigation property, related objects will be added to context and saved with it
        _groupRepository.Create(new LearnerGroup("Group 1", course));

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return course;
    }

    public Result<PagedResult<Course>> GetAll(bool includeArchived, int page, int pageSize)
    {
        return includeArchived ? _courseRepository.GetPaged(page, pageSize) : _courseRepository.GetActive(page, pageSize);
    }

    public Result<Course> Archive(int id, bool archive)
    {
        var courseResult = Get(id);
        if (courseResult.IsFailed) return courseResult;

        var course = courseResult.Value;
        course.IsArchived = archive;
        _courseRepository.Update(course);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(course);
    }
}