namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class SubmissionOpened : TaskProgressEvent
{
    public SubmissionOpened(int stepId)
    {
        StepId = stepId;
    }
    public int StepId { get; private set; }
}

