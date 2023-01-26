using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

public interface IOwnedCourseRepository
{
    CourseOwnership GetCourseOwnership(int courseId, int instructoId);
    List<Course> GetOwnedCourses(int instructorId);
    List<Instructor> GetOwners(int courseId);
    bool IsCourseOwner(int courseId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
    bool IsKcOwner(int kcId, int instructorId);
    Course GetOwnedCourseWithUnitsAndKcs(int courseId, int instructorId);
    void CreateCourseOwnership(CourseOwnership ownership);
    void DeleteCourseOwnership(CourseOwnership ownership);
}