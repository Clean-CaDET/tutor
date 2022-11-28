using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;
using Tutor.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.Core.Domain.KnowledgeMastery.MoveOn;

namespace Tutor.Core.Domain.KnowledgeMastery;

public class KnowledgeComponentMastery : EventSourcedAggregateRoot
{
    private const double PassThreshold = 0.9;

    public int LearnerId { get; private set; }
    public int KnowledgeComponentId { get; private set; }
    public List<AssessmentItemMastery> AssessmentItemMasteries { get; private set; }
    public double Mastery { get; private set; }
    public bool IsStarted { get; private set; }
    public bool IsPassed { get; private set; }
    public bool IsSatisfied { get; private set; }
    public bool IsCompleted { get; private set; }
    public SessionTracker SessionTracker { get; private set; }

    public IMoveOnCriteria MoveOnCriteria { get; set; }

    public KcMasteryStatistics Statistics
    {
        get
        {
            var countPassed = AssessmentItemMasteries.Count(ae => ae.IsPassed);
            var countAttempted = AssessmentItemMasteries.Count(ae => ae.IsAttempted);
            return new KcMasteryStatistics(Mastery, AssessmentItemMasteries.Count, countPassed, countAttempted, IsSatisfied);
        }
    }

    public override void Initialize()
    {
        SessionTracker?.Initialize(this);
        if (AssessmentItemMasteries == null) return;
        foreach (var aim in AssessmentItemMasteries)
            aim.Initialize(this);
    }

    public Result LaunchSession()
    {
        SessionTracker.Launch();
        if (!IsStarted) Causes(new KnowledgeComponentStarted());
        return Result.Ok();
    }

    public Result TerminateSession()
    {
        return SessionTracker.Terminate();
    }

    public Result AbandonSession()
    {
        return SessionTracker.Abandon();
    }

    private void JoinOrLaunchSession()
    {
        if (!SessionTracker.HasUnfinishedSession) LaunchSession();
    }

    public Result RecordInstructionalItemSelection()
    {
        JoinOrLaunchSession();
        Causes(new InstructionalItemsSelected());
        return Result.Ok();
    }

    public Result RecordAssessmentItemSelection(int assessmentItemId)
    {
        var aim = AssessmentItemMasteries.Find(aim => aim.AssessmentItemId == assessmentItemId);
        if (aim == null) return NoAssessmentItemWithId(assessmentItemId);

        JoinOrLaunchSession();
        aim.RecordSelection();

        return Result.Ok();
    }

    public Result RecordAssessmentItemAnswerSubmission(int assessmentItemId, Submission submission, Evaluation evaluation)
    {
        var aim = AssessmentItemMasteries.Find(aim => aim.AssessmentItemId == assessmentItemId);
        if (aim == null) return NoAssessmentItemWithId(assessmentItemId);

        JoinOrLaunchSession();
        aim.RecordAnswerSubmission(submission, evaluation);
        TryPass();
        TryComplete();

        return Result.Ok();
    }

    private void TryPass()
    {
        if (IsPassed || Mastery < PassThreshold) return;

        Causes(new KnowledgeComponentPassed());
        TrySatisfy();
    }

    private void TryComplete()
    {
        if (IsCompleted || AssessmentItemMasteries.Any(am => !am.IsAttempted)) return;

        Causes(new KnowledgeComponentCompleted());
        TrySatisfy();
    }

    private void TrySatisfy()
    {
        if (IsSatisfied || !MoveOnCriteria.IsSatisfied(IsCompleted, IsPassed)) return;

        Causes(new KnowledgeComponentSatisfied());
    }

    public Result RecordAssessmentItemHintRequest(int assessmentItemId)
    {
        var aim = AssessmentItemMasteries.Find(aim => aim.AssessmentItemId == assessmentItemId);
        if (aim == null) return NoAssessmentItemWithId(assessmentItemId);

        JoinOrLaunchSession();
        return aim.RecordHintRequest();
    }

    public Result RecordAssessmentItemSolutionRequest(int assessmentItemId)
    {
        var aim = AssessmentItemMasteries.Find(aim => aim.AssessmentItemId == assessmentItemId);
        if (aim == null) return NoAssessmentItemWithId(assessmentItemId);

        JoinOrLaunchSession();
        return aim.RecordSolutionRequest();
    }

    private static Result NoAssessmentItemWithId(int assessmentItemId)
    {
        return Result.Fail("No mastery for assessment item with id " + assessmentItemId + ". Were masteries created and loaded correctly?");
    }

    public Result RecordInstructorMessage(string message)
    {
        JoinOrLaunchSession();
        Causes(new EncouragingMessageSent
        {
            Message = message
        });
        return Result.Ok();
    }

    protected override void Apply(DomainEvent @event)
    {
        if (@event is not KnowledgeComponentEvent kcEvent) throw new EventSourcingException("Unexpected event type: " + @event.GetType());

        kcEvent.KnowledgeComponentId = KnowledgeComponentId;
        kcEvent.LearnerId = LearnerId;

        SessionTracker.Apply(kcEvent);
        When((dynamic)kcEvent);
    }

    private void When(KnowledgeComponentStarted @event)
    {
        IsStarted = true;
    }

    private void When(KnowledgeComponentPassed @event)
    {
        IsPassed = true;
    }

    private void When(KnowledgeComponentCompleted @event)
    {
        IsCompleted = true;
    }

    private void When(KnowledgeComponentSatisfied @event)
    {
        IsSatisfied = true;
    }

    private void When(AssessmentItemAnswered @event)
    {
        var itemId = @event.AssessmentItemId;
        var assessmentMastery = AssessmentItemMasteries.Find(am => am.AssessmentItemId == itemId);
        if (assessmentMastery == null)
            throw new EventSourcingException("No mastery for assessment item with id: " + itemId + ". Were masteries created and loaded correctly?");

        assessmentMastery.Apply(@event);
        UpdateMastery();
    }

    private void UpdateMastery()
    {
        Mastery = Math.Round(AssessmentItemMasteries.Sum(am => am.Mastery) / AssessmentItemMasteries.Count, 2);
        if (Mastery > 0.97) Mastery = 1; // Resolves rounding errors.
    }

    private static void When(KnowledgeComponentEvent @event)
    {
        // No action for AssessmentItemSelected, InstructionalItemsSelected, SoughtHelp, InstructorMessageEvent, SessionTerminated, SessionAbandoned.
    }
}