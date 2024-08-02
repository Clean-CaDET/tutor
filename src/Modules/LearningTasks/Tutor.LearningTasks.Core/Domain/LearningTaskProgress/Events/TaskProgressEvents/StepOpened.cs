namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class StepOpened : TaskProgressEvent
{
    public StepOpened(int stepId)
    {
        StepId = stepId;
    }
    public int StepId { get; private set; }
}
