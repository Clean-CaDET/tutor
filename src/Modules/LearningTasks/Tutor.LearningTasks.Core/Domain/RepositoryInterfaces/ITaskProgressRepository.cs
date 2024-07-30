using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface ITaskProgressRepository : ICrudRepository<TaskProgress>
{
    new TaskProgress? Get(int id);
    TaskProgress? GetByTask(int taskId, int learnerId);
    List<TaskProgress> GetByTasks(List<int> taskIds, int learnerId);
}
