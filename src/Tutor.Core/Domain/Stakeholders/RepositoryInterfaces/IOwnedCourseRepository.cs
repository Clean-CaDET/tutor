using System.Collections.Generic;
using FluentResults;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IOwnedCourseRepository
{
    List<Course> GetOwnedCourses(int instructorId);
    Result<List<Instructor>> GetOwners(int courseId);
    bool IsCourseOwner(int courseId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
    bool IsKcOwner(int kcId, int instructorId);
    Course GetOwnedCourseWithUnitsAndKcs(int courseId, int instructorId);
    void CreateCourseOwnership(CourseOwnership ownership);
    Result DeleteCourseOwnership(int courseId, int instructorId);
}