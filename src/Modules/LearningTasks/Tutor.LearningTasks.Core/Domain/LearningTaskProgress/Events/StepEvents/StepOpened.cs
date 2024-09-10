namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
public class StepOpened : StepEvent
{
    public StepOpened(int stepId)
    {
        StepId = stepId;
    }
}