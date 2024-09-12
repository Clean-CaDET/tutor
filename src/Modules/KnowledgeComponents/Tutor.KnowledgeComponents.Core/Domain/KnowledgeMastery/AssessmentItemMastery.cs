using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

public class AssessmentItemMastery : EventSourcedEntity
{
    private const double PassThreshold = 0.9;

    public int AssessmentItemId { get; private set; }
    public double Mastery { get; private set; }
    public int SubmissionCount { get; private set; }
    public DateTime? LastSubmissionTime { get; private set; }
    public int HintRequestCount { get; private set; }
    public bool IsAttempted => SubmissionCount > 0;
    public bool IsPassed => Mastery >= PassThreshold;

    private AssessmentItemMastery() {}

    internal AssessmentItemMastery(int itemId)
    {
        AssessmentItemId = itemId;
    }

    public AssessmentItemMastery(int assessmentItemId, double mastery, int submissionCount, DateTime? lastSubmissionTime, int hintRequestCount)
    {
        AssessmentItemId = assessmentItemId;
        Mastery = mastery;
        SubmissionCount = submissionCount;
        LastSubmissionTime = lastSubmissionTime;
        HintRequestCount = hintRequestCount;
    }

    public void RecordSelection(string appClientId)
    {
        Causes(new AssessmentItemSelected
        {
            AssessmentItemId = AssessmentItemId,
            AppClientId = appClientId
        });
    }

    public void RecordAnswerSubmission(Submission submission, Feedback feedback)
    {
        Causes(new AssessmentItemAnswered
        {
            AssessmentItemId = AssessmentItemId,
            Submission = submission,
            Feedback = feedback,
            AttemptCount = SubmissionCount + 1,
            IsFirstCorrect = !IsPassed && feedback.Evaluation.Correct
        });
    }

    public Result RecordHintRequest(string hint)
    {
        Causes(new HintsRequested
        {
            AssessmentItemId = AssessmentItemId,
            Hint = hint
        });
        return Result.Ok();
    }

    public override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }

    private void When(AssessmentItemAnswered @event)
    {
        if (Mastery <= @event.Feedback.Evaluation.CorrectnessLevel) Mastery = @event.Feedback.Evaluation.CorrectnessLevel;
        SubmissionCount++;
        LastSubmissionTime = @event.TimeStamp;
    }

    private void When(HintsRequested @event)
    {
        HintRequestCount++;
    }
}