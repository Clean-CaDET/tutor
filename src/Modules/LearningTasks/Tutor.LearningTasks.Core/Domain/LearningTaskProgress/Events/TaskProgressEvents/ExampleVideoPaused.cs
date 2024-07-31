namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class ExampleVideoPaused : TaskProgressEvent
{
    public ExampleVideoPaused(int stepId)
    {
        StepId = stepId;
    }

    public int StepId { get; private set; }
}