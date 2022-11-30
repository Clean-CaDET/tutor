using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public class CourseOwnershipService : ICourseOwnershipService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly ICourseRepository _courseRepository;

    public CourseOwnershipService(IOwnedCourseRepository ownedCourseRepository, ICourseRepository courseRepository)
    {
        _ownedCourseRepository = ownedCourseRepository;
        _courseRepository = courseRepository;
    }

    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _ownedCourseRepository.GetOwnedCourses(instructorId);
    }

    public Result<Course> GetOwnedCourseWithUnits(int courseId, int instructorId)
    {
        return _ownedCourseRepository.GetOwnedCourseWithUnits(courseId, instructorId);
    }

    public Result AssignOwnership(int courseId, int instructorId)
    {
        var course = _courseRepository.Get(courseId);
        if(course == null) return Result.Fail(FailureCode.NotFound);

        var ownership = new CourseOwnership(course, instructorId);
        _ownedCourseRepository.CreateCourseOwnership(ownership);
        return Result.Ok();
    }

    public Result RemoveOwnership(int courseId, int instructorId)
    {
        _ownedCourseRepository.DeleteCourseOwnership(courseId, instructorId);
        return Result.Ok();
    }
}