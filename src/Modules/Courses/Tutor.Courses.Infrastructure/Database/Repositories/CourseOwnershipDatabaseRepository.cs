using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class CourseOwnershipDatabaseRepository : CrudDatabaseRepository<CourseOwnership, CoursesContext>, ICourseOwnershipRepository
{
    public CourseOwnershipDatabaseRepository(CoursesContext dbContext): base(dbContext) {}

    public CourseOwnership GetByCourseAndInstructor(int courseId, int instructorId)
    {
        return DbContext.CourseOwnerships
            .First(o => o.Course.Id == courseId && o.InstructorId == instructorId);
    }

    public List<Course> GetOwnedCourses(int instructorId)
    {
        return DbContext.CourseOwnerships
            .Where(m => m.InstructorId.Equals(instructorId))
            .Select(m => m.Course).ToList();
    }

    public List<int> GetOwnerIds(int courseId)
    {
        return DbContext.CourseOwnerships
            .Where(m => m.Course.Id.Equals(courseId))
            .Select(m => m.InstructorId).ToList();
    }
}