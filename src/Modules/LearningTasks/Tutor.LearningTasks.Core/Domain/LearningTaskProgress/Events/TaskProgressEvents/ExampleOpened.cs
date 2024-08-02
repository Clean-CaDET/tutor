namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class ExampleOpened : TaskProgressEvent
{
    public ExampleOpened(int stepId)
    {
        StepId = stepId;
    }
    public int StepId { get; private set; }
}
