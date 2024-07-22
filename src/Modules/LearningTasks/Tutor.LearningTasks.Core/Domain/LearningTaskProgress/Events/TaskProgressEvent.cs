using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events;

public abstract class TaskProgresskEvent : DomainEvent
{
    public int LearningTaskId { get; set; }
    public int LearnerId { get; set; }
}
