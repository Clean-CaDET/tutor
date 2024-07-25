using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.EventSourcing;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class TaskProgressDatabaseRepository : CrudDatabaseRepository<TaskProgress, LearningTasksContext>, ITaskProgressRepository
{
    private readonly ILearningTaskEventStore _eventStore;

    public TaskProgressDatabaseRepository(LearningTasksContext dbContext, ILearningTaskEventStore eventStore) : base(dbContext)
    {
        _eventStore = eventStore;
    }

    public new TaskProgress? Get(int id)
    {
        return DbContext.TaskProgresses.Where(p => p.Id == id)
            .Include(p => p.StepProgresses!)
            .FirstOrDefault();
    }

    public TaskProgress? GetByTaskAndLearner(int taskId, int learnerId)
    {
        return DbContext.TaskProgresses.Where(p => p.LearningTaskId == taskId && p.LearnerId == learnerId)
            .Include(p => p.StepProgresses!)
            .FirstOrDefault();
    }
    public void UpdateEvents(TaskProgress taskProgress)
    {
        _eventStore.Save(taskProgress);
    }
}