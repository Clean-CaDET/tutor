using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface ICourseOwnershipRepository : ICrudRepository<CourseOwnership>
{
    CourseOwnership GetByCourseAndInstructor(int courseId, int instructorId);
    List<Course> GetOwnedCourses(int instructorId);
    List<int> GetOwnerIds(int courseId);
}