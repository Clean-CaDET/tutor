using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

public class KnowledgeComponentMastery : EventSourcedAggregateRoot
{
    private const double PassThreshold = 0.9;

    public int LearnerId { get; private set; }
    public KnowledgeComponent KnowledgeComponent { get; private set; }
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
            var countCompleted = AssessmentItemMasteries.Count(ae => ae.IsCompleted);
            return new KcMasteryStatistics(Mastery, AssessmentItemMasteries.Count, countPassed, countCompleted, IsSatisfied);
        }
    }

    public override void Initialize()
    {
        if (SessionTracker != null)
            SessionTracker.Initialize(this);
        if (AssessmentItemMasteries != null)
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

    public Result RecordAssessmentItemInteraction(AssessmentItemInteraction interaction)
    {
        var aim = AssessmentItemMasteries.Find(aim => aim.AssessmentItemId == interaction.AssessmentItemId);
        if (aim == null) return Result.Fail("No mastery for assessment item with id " + interaction.AssessmentItemId +
                                            ". Were masteries created and loaded correctly?");

        JoinOrLaunchSession();
        var result = aim.RecordInteraction(interaction);
        if (result.IsSuccess)
        {
            TryPass();
            TryComplete();
        }
        return result;
    }

    private void TryPass()
    {
        if (IsPassed || Mastery < PassThreshold) return;

        Causes(new KnowledgeComponentPassed());
        TrySatisfy();
    }

    private void TryComplete()
    {
        if (IsCompleted || AssessmentItemMasteries.Any(am => !am.IsCompleted)) return;

        Causes(new KnowledgeComponentCompleted());
        TrySatisfy();
    }

    private void TrySatisfy()
    {
        if (IsSatisfied || !MoveOnCriteria.IsSatisfied(IsCompleted, IsPassed)) return;

        Causes(new KnowledgeComponentSatisfied());
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
        var kcEvent = @event as KnowledgeComponentEvent;
        if (kcEvent == null) throw new EventSourcingException("Unexpected event type: " + @event.GetType());

        kcEvent.KnowledgeComponentId = KnowledgeComponent.Id;
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

    private void When(AssessmentItemEvent @event)
    {
        var aim = AssessmentItemMasteries.Find(am => am.AssessmentItemId == @event.AssessmentItemId);
        if (aim == null)
            throw new EventSourcingException("No mastery for assessment item with id: " + @event.AssessmentItemId +
                                            ". Were masteries created and loaded correctly?");

        var aimBeforeEvent = aim.Mastery;
        aim.Apply(@event);
        if (aimBeforeEvent != aim.Mastery) UpdateMastery();
    }

    private void UpdateMastery()
    {
        Mastery = Math.Round(AssessmentItemMasteries.Sum(aim => aim.Mastery) / AssessmentItemMasteries.Count, 2);
        if (Mastery > 0.97) Mastery = 1; // Resolves rounding errors.
    }

    private static void When(KnowledgeComponentEvent @event)
    {
        // No action for InstructionalItemsSelected, InstructorMessageEvent, SessionLifecycleEvents.
    }
}