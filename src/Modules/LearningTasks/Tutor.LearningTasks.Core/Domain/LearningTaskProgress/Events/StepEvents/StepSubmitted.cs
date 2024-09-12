namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
public class StepSubmitted : StepEvent
{
    public string Answer { get; private set; }

    public StepSubmitted(int stepId, string answer)
    {
        StepId = stepId;
        Answer = answer;
    }
}