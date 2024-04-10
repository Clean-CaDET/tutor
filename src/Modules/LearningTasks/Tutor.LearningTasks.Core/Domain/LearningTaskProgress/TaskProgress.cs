using Tutor.BuildingBlocks.Core.Domain;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class TaskProgress : AggregateRoot
{
    public int LearningTaskId { get; private set; }
    public int LearnerId { get; private set; }
    public double TotalScore { get; private set; }
    public TaskStatus Status { get; private set; }
    public List<StepProgress>? StepProgresses { get; private set; }

    public TaskProgress() { }

    public TaskProgress(List<Activity> steps, int learningTaskId, int learnerId)
    {
        Status = TaskStatus.Initialized;
        LearningTaskId = learningTaskId;
        LearnerId = learnerId;
        CreateStepProgresses(steps);
    }

    private void CreateStepProgresses(List<Activity> steps)
    {
        StepProgresses = new List<StepProgress>();
        foreach (var step in steps)
        {
            if (step.ParentId == 0)
                StepProgresses.Add(new StepProgress(step.Id, LearnerId));
        }
    }

    public void SubmitAnswer(int stepId, string answer)
    {
        var stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        stepProgress?.SubmitAnswer(answer);

        var allStepsAnswered = StepProgresses!.All(s => s.Status == StepStatus.Answered);
        if (allStepsAnswered)
            Status = TaskStatus.Completed;
    }

    public void ViewStep(int stepId)
    {
        var stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        stepProgress?.MarkAsViewed();
    }
}

public enum TaskStatus
{
    Initialized, Assigned, Completed, Graded
}
