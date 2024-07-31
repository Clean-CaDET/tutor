using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

public class TaskProgress : EventSourcedAggregateRoot
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
        Causes(new StepSubmitted(stepId));

        var allStepsAnswered = StepProgresses!.All(s => s.Status == StepStatus.Answered);
        if (allStepsAnswered)
        {
            Status = TaskStatus.Completed;
            Causes(new TaskCompleted());
        }
    }

    public void ViewStep(int stepId)
    {
        var stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        stepProgress?.MarkAsViewed();

        Causes(new StepOpened(stepId));
        Causes(new SubmissionOpened(stepId));
    }

    public Result TaskOpened()
    {
        Causes(new TaskOpened());
        return Result.Ok();
    }

    public Result OpenSubmission(int stepId)
    {
        Causes(new SubmissionOpened(stepId));
        return Result.Ok();
    }

    public Result OpenGuidance(int stepId)
    {
        Causes(new GuidanceOpened(stepId));
        return Result.Ok();
    }

    public Result OpenExample(int stepId)
    {
        Causes(new ExampleOpened(stepId));
        return Result.Ok();
    }

    public Result PlayExampleVideo(int stepId)
    {
        Causes(new ExampleVideoPlayed(stepId));
        return Result.Ok();
    }

    public Result PauseExampleVideo(int stepId)
    {
        Causes(new ExampleVideoPaused(stepId));
        return Result.Ok();
    }

    public Result FinishExampleVideo(int stepId)
    {
        Causes(new ExampleVideoFinished(stepId));
        return Result.Ok();
    }

    protected override void Apply(DomainEvent @event)
    {
        if (@event is not TaskProgressEvent kcEvent) throw new EventSourcingException("Unexpected event type: " + @event.GetType());

        kcEvent.LearningTaskId = LearningTaskId;
        kcEvent.LearnerId = LearnerId;

        When((dynamic)kcEvent);
    }

    private static void When(TaskProgressEvent @event)
    {
        // No additional actions are required for all events.
    }
}

public enum TaskStatus
{
    Initialized, Assigned, Completed, Graded
}
