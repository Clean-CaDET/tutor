using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface ITaskProgressRepository : ICrudRepository<TaskProgress>
{
    new TaskProgress? Get(int id);
    void UpdateEvents(TaskProgress taskProgress);
    TaskProgress? GetByTask(int taskId, int learnerId);
    List<TaskProgress> GetByTasks(List<int> taskIds, int learnerId);
    int CountCompletedOrGraded(List<int> taskIds, int learnerId);
}
