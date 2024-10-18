using Tutor.BuildingBlocks.Core.Domain;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class StepProgress : Entity
{
    public string? Answer { get; private set; }
    public StepStatus Status { get; private set; }
    public int StepId { get; private set; }
    public int LearnerId { get; private set; }
    public List<StandardEvaluation>? Evaluations { get; private set; }
    public string? Comment { get; private set; }

    public StepProgress() { }

    public StepProgress(int stepId, int learnerId, List<Standard> standards)
    {
        Status = StepStatus.Initialized;
        StepId = stepId;
        LearnerId = learnerId;
    }

    public bool IsCompleted()
    {
        return Status == StepStatus.Answered || Status == StepStatus.Graded;
    }

    public void SubmitAnswer(string answer)
    {
        Answer = answer;
        Status = StepStatus.Answered;
    }

    public void MarkAsViewed()
    {
        if (Status == StepStatus.Initialized)
        {
            Status = StepStatus.Viewed;
        }
    }

    public void SubmitGrade(List<StandardEvaluation> evaluations, string comment)
    {
        Evaluations = evaluations;
        Comment = comment;
        MarkAsGraded();
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
