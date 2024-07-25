using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface ITaskProgressRepository : ICrudRepository<TaskProgress>
{
    new TaskProgress? Get(int id);
    TaskProgress? GetByTaskAndLearner(int taskId, int learnerId);

    void UpdateEvents(TaskProgress taskProgress);
}
