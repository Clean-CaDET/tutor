using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.Activities;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class ActivityDatabaseRepository : CrudDatabaseRepository<Activity, LearningTasksContext>, IActivityRepository
{
    public ActivityDatabaseRepository(LearningTasksContext dbContext) : base(dbContext) {}

    public List<Activity> GetCourseActivities(int courseId)
    {
        return DbContext.Activities.Where(a => a.CourseId == courseId).ToList();
    }
}