using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class StepProgress : Entity
{
    public string? Answer { get; private set; }
    public string? CommentForMentor { get; private set; }
    public DateTime? LastAnsweredAt { get; private set; }
    public StepStatus Status { get; private set; }
    public int StepId { get; private set; }
    public int LearnerId { get; private set; }
    public List<StandardEvaluation>? Evaluations { get; private set; }
    public string? Comment { get; private set; }
    public DateTime? LastGradedAt { get; private set; }

    public StepProgress() { }

    public StepProgress(int stepId, int learnerId)
    {
        Status = StepStatus.Initialized;
        StepId = stepId;
        LearnerId = learnerId;
    }

    public bool IsCompleted()
    {
        return Status == StepStatus.Answered || Status == StepStatus.Graded;
    }

    public void SubmitAnswer(string answer, string? commentForMentor, DateTime answeredAt)
    {
        Answer = answer;
        CommentForMentor = commentForMentor;
        LastAnsweredAt = answeredAt;
        if (Status != StepStatus.Graded)
        {
            Status = StepStatus.Answered;
        }
    }

    public void MarkAsViewed()
    {
        if (Status == StepStatus.Initialized)
        {
            Status = StepStatus.Viewed;
        }
    }

    public void SubmitGrade(List<StandardEvaluation> evaluations, string comment, DateTime gradedAt)
    {
        Evaluations = evaluations;
        Comment = comment;
        MarkAsGraded();
        LastGradedAt = gradedAt;
    }

    private void MarkAsGraded()
    {
        if (Status == StepStatus.Answered)
        {
            Status = StepStatus.Graded;
        }
    }
}

public enum StepStatus
{
    Initialized, Viewed, Answered, Graded
}
