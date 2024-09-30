namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
public class TaskGraded : TaskEvent
{
    public double TotalScore { get; set; }
}
