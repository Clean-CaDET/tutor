
namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;

public class StepSubmitted : TaskProgresskEvent
{
    public StepSubmitted(int stepId)
    {
        StepId = stepId;
    }
    public int StepId { get; private set; }
}
