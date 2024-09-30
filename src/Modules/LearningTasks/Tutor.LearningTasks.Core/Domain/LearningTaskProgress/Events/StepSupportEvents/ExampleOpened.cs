namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
public class ExampleOpened : StepSupportEvent
{
    public ExampleOpened(int stepId)
    {
        StepId = stepId;
    }
}