using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;

public abstract class StepEvent : TaskEvent
{
    public int StepId { get; set; }
}