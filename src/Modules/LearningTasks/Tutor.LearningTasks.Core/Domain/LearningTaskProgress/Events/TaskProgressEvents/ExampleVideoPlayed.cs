namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class ExampleVideoPlayed : TaskProgressEvent
{
    public ExampleVideoPlayed(int stepId)
    {
        StepId = stepId;
    }

    public int StepId { get; private set; }
}