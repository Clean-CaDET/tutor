using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IOwnedCourseRepository
{
    List<Course> GetOwnedCourses(int instructorId);
    Result<List<Instructor>> GetOwners(int courseId);
    bool IsOwner(int courseId, int instructorId);
    CourseOwnership CheckUnitOwnership(int unitId, int instructorId);
    Course GetOwnedCourseWithUnitsAndKcs(int courseId, int instructorId);
    void CreateCourseOwnership(CourseOwnership ownership);
    void DeleteCourseOwnership(int courseId, int instructorId);
}