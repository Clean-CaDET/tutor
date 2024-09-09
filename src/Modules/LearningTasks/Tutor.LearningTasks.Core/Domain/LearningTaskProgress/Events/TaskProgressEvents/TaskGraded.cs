namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class TaskGraded : TaskProgressEvent
{
    public double TotalScore { get; set; }
}
