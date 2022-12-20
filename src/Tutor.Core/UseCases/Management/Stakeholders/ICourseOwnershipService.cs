using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ICourseOwnershipService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);
    Result<List<Instructor>> GetOwners(int courseId);
    Result<Course> GetOwnedCourseWithUnits(int courseId, int instructorId);
    Result<Course> AssignOwnership(int courseId, int instructorId);
    Result RemoveOwnership(int courseId, int instructorId);
}