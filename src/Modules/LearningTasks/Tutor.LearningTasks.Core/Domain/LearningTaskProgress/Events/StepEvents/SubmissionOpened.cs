namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
public class SubmissionOpened : StepEvent
{
    public SubmissionOpened(int stepId)
    {
        StepId = stepId;
    }
}