using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.UseCases;

namespace Tutor.LearningTasks.Infrastructure.Database;

public class LearningTasksUnitOfWork : UnitOfWork<LearningTasksContext>, ILearningTasksUnitOfWork
{
    public LearningTasksUnitOfWork(LearningTasksContext dbContext) : base(dbContext) {}
}
