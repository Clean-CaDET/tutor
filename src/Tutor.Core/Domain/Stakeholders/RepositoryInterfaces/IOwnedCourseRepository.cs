using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IOwnedCourseRepository
{
    List<Course> GetOwnedCourses(int instructorId);
    Result<List<Instructor>> GetOwners(int courseId);
    Course GetOwnedCourseWithUnits(int courseId, int instructorId);
    void CreateCourseOwnership(CourseOwnership ownership);
    void DeleteCourseOwnership(int courseId, int instructorId);
}