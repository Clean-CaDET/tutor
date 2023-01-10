using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ICourseOwnershipService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);
    Result<Course> GetOwnedCourseWithUnitsAndKcs(int courseId, int instructorId);
    Result<Course> UpdateOwnedCourse(Course course, int instructorId);

    Result<List<Instructor>> GetOwners(int courseId);
    Result<Course> AssignOwnership(int courseId, int instructorId);
    Result RemoveOwnership(int courseId, int instructorId);
}