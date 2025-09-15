namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
public class StepSubmitted : StepEvent
{
    public string Answer { get; private set; }
    public string? CommentForMentor { get; private set; }

    public StepSubmitted(int stepId, string answer, string? commentForMentor)
    {
        StepId = stepId;
        Answer = answer;
        CommentForMentor = commentForMentor;
    }
}