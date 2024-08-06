namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class StepSubmitted : TaskProgressEvent
{
    public StepSubmitted(int stepId, string answer)
    {
        StepId = stepId;
        Answer = answer;
    }
    public int StepId { get; private set; }

    public string Answer { get; private set; }
}
