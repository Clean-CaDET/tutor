using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.Activites;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class ActivityDatabaseRepository : CrudDatabaseRepository<Activity, LearningTasksContext>, IActivityRepository
{
    public ActivityDatabaseRepository(LearningTasksContext dbContext) : base(dbContext) {}

    public Activity GetWithExamples(int id)
    {
        return DbContext.Activities.Include(a => a.Examples).First(a => a.Id == id);
    }

    public List<Activity> GetCourseActivitiesWithExamples(int courseId)
    {
        var activitiesWithExamples = DbContext.Activities
            .Include(a => a.Examples)
            .ToList();
        return activitiesWithExamples.Where(a => a.CourseId == courseId).ToList();
    }
}
