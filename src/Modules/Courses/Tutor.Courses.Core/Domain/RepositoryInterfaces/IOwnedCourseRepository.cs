namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IOwnedCourseRepository
{
    List<Course> GetAll(int instructorId);
    bool IsCourseOwner(int courseId, int instructorId);
    bool IsUnitOwner(int unitId, int instructorId);
}