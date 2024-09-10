using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
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
        StepProgresses = steps
            .Where(step => step.ParentId == 0)
            .Select(step => new StepProgress(step.Id, LearnerId, step.Standards!))
            .ToList();
    }

    public bool IsCompleted()
    {
        return Status == TaskStatus.Completed || Status == TaskStatus.Graded;
    }

    public void SubmitAnswer(int stepId, string answer)
    {
        Causes(new StepSubmitted(stepId, answer));

        var allStepsAnswered = StepProgresses!.All(s => s.Status == StepStatus.Answered);
        if (allStepsAnswered)
        {
            Causes(new TaskCompleted());
        }
    }

    public void SubmitGrade(int stepId, List<StandardEvaluation> evaluations, string comment)
    {
        Causes(new StepGraded(stepId, evaluations, comment));

        var allStepsAnswered = StepProgresses!.All(s => s.Status == StepStatus.Graded);
        if (allStepsAnswered)
        {
            Causes(new TaskGraded());
        }
    }

    public void ViewStep(int stepId)
    {
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

    public Result PlayExampleVideo(int stepId, string videoUrl)
    {
        Causes(new ExampleVideoPlayed(stepId, videoUrl));
        return Result.Ok();
    }

    public Result PauseExampleVideo(int stepId, string videoUrl)
    {
        Causes(new ExampleVideoPaused(stepId, videoUrl));
        return Result.Ok();
    }

    public Result FinishExampleVideo(int stepId, string videoUrl)
    {
        Causes(new ExampleVideoFinished(stepId, videoUrl));
        return Result.Ok();
    }

    protected override void Apply(DomainEvent @event)
    {
        if (@event is not TaskEvent kcEvent) throw new EventSourcingException("Unexpected event type: " + @event.GetType());

        kcEvent.LearningTaskId = LearningTaskId;
        kcEvent.LearnerId = LearnerId;

        When((dynamic)kcEvent);
    }

    private void When(StepSubmitted @event)
    {
        var stepId = @event.StepId;
        var answer = @event.Answer;

        var stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        stepProgress?.SubmitAnswer(answer);
    }

    private void When(StepGraded @event)
    {
        var stepProgress = StepProgresses?.Find(s => s.StepId.Equals(@event.StepId));
        stepProgress?.SubmitGrade(@event.Evaluations, @event.Comment);
    }

    private void When(TaskCompleted @event)
    {
        Status = TaskStatus.Completed;
    }

    private void When(TaskGraded @event)
    {
        foreach (var stepProgress in StepProgresses!)
        {
            TotalScore += stepProgress.Evaluations!.Sum(e => e.Points);
        }
        Status = TaskStatus.Graded;
        @event.TotalScore = TotalScore;
    }

    private void When(StepOpened @event)
    {
        var stepId = @event.StepId;

        var stepProgress = StepProgresses?.Find(s => s.StepId.Equals(stepId));
        stepProgress?.MarkAsViewed();
    }

    private static void When(TaskEvent @event)
    {
        // No additional actions are required for TaskOpened, SubmissionOpened, GuidanceOpened, ExampleOpened
        // ExampleVideoPlayed, ExampleVideoPaused, ExampleVideoFinished.
    }
}

public enum TaskStatus
{
    Initialized, Assigned, Completed, Graded
}
