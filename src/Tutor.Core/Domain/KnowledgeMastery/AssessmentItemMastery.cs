using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.Core.Domain.KnowledgeMastery;

public class AssessmentItemMastery : EventSourcedEntity
{
    private const double PassThreshold = 0.9;

    public int AssessmentItemId { get; private set; }
    public double Mastery { get; private set; }
    public int SubmissionCount { get; private set; }
    public DateTime? LastSubmissionTime { get; set; }
    public bool IsAttempted => SubmissionCount > 0;
    public bool IsPassed => Mastery > PassThreshold;

    public void RecordSelection()
    {
        Causes(new AssessmentItemSelected()
        {
            AssessmentItemId = AssessmentItemId,
        });
    }

    public void RecordAnswerSubmission(Submission submission, Evaluation evaluation)
    {
        Causes(new AssessmentItemAnswered
        {
            AssessmentItemId = AssessmentItemId,
            Submission = submission,
            Evaluation = evaluation
        });
    }

    public Result RecordHintRequest()
    {
        Causes(new HintsRequested());
        return Result.Ok();
    }

    public Result RecordSolutionRequest()
    {
        Causes(new SolutionRequested());
        return Result.Ok();
    }

    public override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }

    private void When(AssessmentItemAnswered @event)
    {
        if (Mastery <= @event.Evaluation.CorrectnessLevel) Mastery = @event.Evaluation.CorrectnessLevel;
        SubmissionCount++;
        LastSubmissionTime = @event.TimeStamp;
    }
}