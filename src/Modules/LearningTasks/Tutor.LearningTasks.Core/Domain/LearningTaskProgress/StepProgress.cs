using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class StepProgress : Entity
{
    public string? Answer { get; private set; }
    public StepStatus Status { get; private set; } 
    public int StepId { get; private set; }
    public int LearnerId { get; private set; }

    public StepProgress() { }

    public StepProgress(int stepId, int learnerId)
    {
        Status = StepStatus.Initialized;
        StepId = stepId;
        LearnerId = learnerId;
    }

    public void SubmitAnswer(string answer)
    {
        Answer = answer;
        Status = StepStatus.Answered;
    }

    public void MarkAsViewed()
    {
        if(Status == StepStatus.Initialized)
        {
            Status = StepStatus.Viewed;
        }
    }
}

public enum StepStatus
{
    Initialized, Viewed, Answered, Graded
}
