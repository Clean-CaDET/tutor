using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.StakeholderManagement;

public class CourseOwnershipService : ICourseOwnershipService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public CourseOwnershipService(IOwnedCourseRepository ownedCourseRepository)
    {
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _ownedCourseRepository.GetOwnedCourses(instructorId);
    }

    public Result<Course> GetOwnedCourseWithUnits(int courseId, int instructorId)
    {
        return _ownedCourseRepository.GetOwnedCourseWithUnits(courseId, instructorId);
    }
}