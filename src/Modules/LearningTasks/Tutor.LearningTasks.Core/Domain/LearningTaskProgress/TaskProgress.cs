using Tutor.BuildingBlocks.Core.Domain;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class TaskProgress : AggregateRoot
{
    public double TotalScore { get; private set; }
    public TaskStatus Status { get; private set; }
    public List<StepProgress>? StepProgresses { get; private set; }
    public int LearningTaskId { get; private set; }
    public int LearnerId { get; private set; }

    public TaskProgress() { }

    public TaskProgress(int learningTaskId, int learnerId)
    {
        Status = TaskStatus.Initilized;
        LearningTaskId = learningTaskId;
        LearnerId = learnerId;
    }

    public void SubmitAnswer(int stepId, string answer)
    {
        StepProgress? stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        if (stepProgress != null)
              stepProgress.SubmitAnswer(answer);

        bool allStepsAnswered = StepProgresses!.All(s => s.Status == StepStatus.Answered);
        if (allStepsAnswered)
            Status = TaskStatus.Completed;
    }

    public void ViewStep(int stepId)
    {
        StepProgress? stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        if (stepProgress != null && stepProgress.Status == StepStatus.Initilized)
        {
            stepProgress.MarkAsViewed();
        }
    }

    public void CreateStepProgresses(List<Activity> steps)
    {
        StepProgresses = new List<StepProgress>();
        foreach (var step in steps)
        {
            StepProgresses.Add(new StepProgress(step.Id, LearnerId));
        }
    }
}

public enum TaskStatus
{
    Initilized, Completed, Graded
}
