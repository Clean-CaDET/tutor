namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class ExampleVideoPlayed : TaskProgresskEvent
{
    public ExampleVideoPlayed(int stepId)
    {
        StepId = stepId;
    }

    public int StepId { get; private set; }
}