using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class OwnedCourseDatabaseRepository : IOwnedCourseRepository
{
    private readonly CoursesContext _dbContext;

    public OwnedCourseDatabaseRepository(CoursesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Course> GetAll(int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.InstructorId.Equals(instructorId))
            .Select(m => m.Course).ToList();
    }

    public bool IsCourseOwner(int courseId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Any(m => m.InstructorId.Equals(instructorId) && m.Course.Id.Equals(courseId));
    }

    public bool IsUnitOwner(int unitId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Any(m => m.InstructorId.Equals(instructorId)
                      && m.Course.KnowledgeUnits.Any(ku => ku.Id.Equals(unitId)));
    }
}