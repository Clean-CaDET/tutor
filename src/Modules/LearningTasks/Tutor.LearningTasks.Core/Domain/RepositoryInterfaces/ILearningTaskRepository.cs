using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface ILearningTaskRepository : ICrudRepository<LearningTask>
{
    new LearningTask? Get(int id);
    List<LearningTask> GetUnitLearningTasks(int unitId);
}
