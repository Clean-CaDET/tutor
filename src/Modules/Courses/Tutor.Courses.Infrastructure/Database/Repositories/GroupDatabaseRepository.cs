using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class GroupDatabaseRepository : CrudDatabaseRepository<LearnerGroup, CoursesContext>, IGroupRepository
{
    public GroupDatabaseRepository(CoursesContext dbContext) : base(dbContext) {}

    public List<LearnerGroup> GetCourseGroups(int courseId)
    {
        return DbContext.LearnerGroups.Where(g => g.CourseId == courseId).ToList();
    }
}