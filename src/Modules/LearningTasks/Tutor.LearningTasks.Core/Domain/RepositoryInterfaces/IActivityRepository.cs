using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.Activities;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface IActivityRepository : ICrudRepository<Activity>
{
    List<Activity> GetCourseActivities(int courseId);
    List<Activity> GetSubactivities(int activityId);
}
