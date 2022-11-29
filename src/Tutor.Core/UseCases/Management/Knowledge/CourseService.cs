using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public class CourseService : ICourseService
{
    private readonly ICrudCourseRepository _courseRepository;
    public CourseService (ICrudCourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public Result<List<Course>> GetAll(bool includeArchived)
    {
        return includeArchived ? _courseRepository.GetAll() : _courseRepository.GetActive();
    }

    public Result<Course> Create(Course course)
    {
        var createdCourse = _courseRepository.Create(course);
        return Result.Ok(createdCourse);
    }

    public Result Update(Course course)
    {
        _courseRepository.Update(course);
        return Result.Ok();
    }

    public Result Delete(int id)
    {
        _courseRepository.Delete(id);
        return Result.Ok();
    }
}