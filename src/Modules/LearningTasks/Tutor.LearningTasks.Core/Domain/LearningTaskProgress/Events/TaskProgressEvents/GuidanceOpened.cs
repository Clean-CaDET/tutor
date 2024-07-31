namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class GuidanceOpened : TaskProgressEvent
{
    public GuidanceOpened(int stepId)
    {
        StepId = stepId;
    }
    public int StepId { get; private set; }
}
