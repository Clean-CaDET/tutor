namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
public class GuidanceOpened : StepSupportEvent
{
    public GuidanceOpened(int stepId)
    {
        StepId = stepId;
    }
}