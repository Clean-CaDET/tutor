using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public interface ICourseOwnershipService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);
    Result<Course> GetOwnedCourseWithUnits(int courseId, int instructorId);
}