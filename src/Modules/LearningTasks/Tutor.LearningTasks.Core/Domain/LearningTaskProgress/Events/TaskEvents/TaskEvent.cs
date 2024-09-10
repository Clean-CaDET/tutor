using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;

public abstract class TaskEvent : DomainEvent
{
    public int LearningTaskId { get; set; }
    public int LearnerId { get; set; }
}
