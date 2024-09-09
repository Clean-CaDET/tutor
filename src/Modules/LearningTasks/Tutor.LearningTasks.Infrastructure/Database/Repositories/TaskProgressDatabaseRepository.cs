using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;
using TaskStatus = Tutor.LearningTasks.Core.Domain.LearningTaskProgress.TaskStatus;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class TaskProgressDatabaseRepository : CrudDatabaseRepository<TaskProgress, LearningTasksContext>, ITaskProgressRepository
{
    private readonly IEventStore<TaskProgressEvent> _eventStore;

    public TaskProgressDatabaseRepository(LearningTasksContext dbContext, IEventStore<TaskProgressEvent> eventStore) : base(dbContext)
    {
        _eventStore = eventStore;
    }

    public new TaskProgress? Get(int id)
    {
        return DbContext.TaskProgresses.Where(p => p.Id == id)
            .Include(p => p.StepProgresses!)
            .FirstOrDefault();
    }

    public TaskProgress? GetByTask(int taskId, int learnerId)
    {
        return DbContext.TaskProgresses.Where(p => p.LearningTaskId == taskId && p.LearnerId == learnerId)
            .Include(p => p.StepProgresses!)
            .FirstOrDefault();
    }
    public void UpdateEvents(TaskProgress taskProgress)
    {
        DbContext.TaskProgresses.Attach(taskProgress);
        _eventStore.Save(taskProgress);
    }

    public List<TaskProgress> GetByTasks(List<int> taskIds, int learnerId)
    {
        return DbContext.TaskProgresses
            .Where(p => p.LearnerId == learnerId && taskIds.Contains(p.LearningTaskId))
            .Include(p => p.StepProgresses)
            .ToList();
    }

    public List<TaskProgress> GetByTasksAndGroup(int[] taskIds, int[] groupMemberIds)
    {
        return DbContext.TaskProgresses
            .Where(p => groupMemberIds.Contains(p.LearnerId) && taskIds.Contains(p.LearningTaskId))
            .Include(p => p.StepProgresses)
            .ToList();
    }

    public int CountCompletedOrGraded(List<int> taskIds, int learnerId)
    {
        return DbContext.TaskProgresses
            .Count(p => 
                p.LearnerId == learnerId && taskIds.Contains(p.LearningTaskId) &&
                p.Status == TaskStatus.Completed || p.Status == TaskStatus.Graded);
    }
}