namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class ExampleVideoFinished : TaskProgresskEvent
{
    public ExampleVideoFinished(int stepId)
    {
        StepId = stepId;
    }

    public int StepId { get; private set; }
}