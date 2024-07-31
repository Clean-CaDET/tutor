namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class ExampleVideoFinished : TaskProgressEvent
{
    public ExampleVideoFinished(int stepId)
    {
        StepId = stepId;
    }

    public int StepId { get; private set; }
}