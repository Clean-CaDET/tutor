using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.Activites;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface IActivityRepository : ICrudRepository<Activity>
{
    Activity GetWithExamples(int id);
    List<Activity> GetCourseActivitiesWithExamples(int courseId);
}
