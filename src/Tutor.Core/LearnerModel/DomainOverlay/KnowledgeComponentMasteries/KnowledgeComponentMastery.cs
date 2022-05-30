using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

public class KnowledgeComponentMastery : EventSourcedAggregateRoot
{
    private const double PassThreshold = 0.9;

    public int LearnerId { get; private set; }
    public KnowledgeComponent KnowledgeComponent { get; private set; }
    public List<AssessmentItemMastery> AssessmentMasteries { get; private set; }
    public double Mastery { get; private set; }
    public bool HasActiveSession { get; private set; }
    public bool IsStarted { get; private set; }
    public bool IsPassed { get; private set; }
    public bool IsSatisfied { get; private set; }
    public bool IsCompleted { get; private set; }

    public IMoveOnCriteria MoveOnCriteria { get; set; }

    public KcMasteryStatistics Statistics
    {
        get
        {
            var countCompleted = AssessmentMasteries.Count(ae => ae.Mastery > PassThreshold);
            var countAttempted = AssessmentMasteries.Count(ae => ae.IsAttempted());
            return new KcMasteryStatistics(Mastery, AssessmentMasteries.Count, countCompleted, countAttempted, IsSatisfied);
        }
    }

    public Result LaunchSession()
    {
        if (HasActiveSession)
        {
            Causes(new SessionAbandoned
            {
                KnowledgeComponentId = KnowledgeComponent.Id,
                LearnerId = LearnerId
            });
        }

        Causes(new SessionLaunched
        {
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        });
        TryStart();
        return Result.Ok();
    }

    private void TryStart()
    {
        if (IsStarted) return;

        Causes(new KnowledgeComponentStarted
        {
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        });
    }

    public Result TerminateSession()
    {
        if (!HasActiveSession) return Result.Fail("No active session to terminate.");

        Causes(new SessionTerminated
        {
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        });
        return Result.Ok();
    }

    public Result SubmitAssessmentItemAnswer(int assessmentItemId, Submission submission, Evaluation evaluation)
    {
        if (!HasActiveSession) LaunchSession();
            
        Causes(new AssessmentItemAnswered
        {
            LearnerId = LearnerId,
            KnowledgeComponentId = KnowledgeComponent.Id,
            AssessmentItemId = assessmentItemId,
            Submission = submission,
            Evaluation = evaluation
        });

        TryPass();
        TryComplete();

        return Result.Ok();
    }

    public Result<int> SelectSuitableAssessmentItemId(IAssessmentItemSelector assessmentItemSelector)
    {
        if (!HasActiveSession) LaunchSession();

        var result = assessmentItemSelector.SelectSuitableAssessmentItemId(AssessmentMasteries, IsPassed);
        if (result.IsFailed) return result;

        Causes(new AssessmentItemSelected
        {
            LearnerId = LearnerId,
            KnowledgeComponentId = KnowledgeComponent.Id,
            AssessmentItemId = result.Value
        });

        return result;
    }

    public Result<List<InstructionalItem>> GetInstructionalItems()
    {
        if (!HasActiveSession) LaunchSession();

        Causes(new InstructionalItemsSelected
        {
            LearnerId = LearnerId,
            KnowledgeComponentId = KnowledgeComponent.Id
        });
        return Result.Ok(KnowledgeComponent.InstructionalItems.OrderBy(i => i.Order).ToList());
    }

    private void TryPass()
    {
        if (IsPassed || Mastery < PassThreshold) return;

        Causes(new KnowledgeComponentPassed
        {
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        });
        TrySatisfy();
    }

    private void TryComplete()
    {
        if (IsCompleted || AssessmentMasteries.Any(am => !am.IsAttempted())) return;

        Causes(new KnowledgeComponentCompleted
        {
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        });
        TrySatisfy();
    }

    private void TrySatisfy()
    {
        if (IsSatisfied || !MoveOnCriteria.IsSatisfied(IsCompleted, IsPassed)) return;

        Causes(new KnowledgeComponentSatisfied
        {
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        });
    }

    public Result SeekHelpForAssessmentItem(SoughtHelp helpEvent)
    {
        if (!HasActiveSession) LaunchSession();
        helpEvent.KnowledgeComponentId = KnowledgeComponent.Id;
        helpEvent.LearnerId = LearnerId;

        Causes(helpEvent);
        return Result.Ok();
    }

    public Result RecordInstructorMessage(string message)
    {
        var instructorMessageEvent = new EncouragingMessageSent
        {
            Message = message,
            KnowledgeComponentId = KnowledgeComponent.Id,
            LearnerId = LearnerId
        };
        Causes(instructorMessageEvent);
        return Result.Ok();
    }

    protected override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }

    private void When(SessionLaunched @event)
    {
        HasActiveSession = true;
    }

    private void When(SessionTerminated @event)
    {
        HasActiveSession = false;
    }

    private void When(SessionAbandoned @event)
    {
        HasActiveSession = false;
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

    private static void When(KnowledgeComponentEvent @event)
    {
        // No action for AssessmentItemSelected, InstructionalItemsSelected, SoughtHelp, InstructorMessageEvent.
    }

    private void When(AssessmentItemAnswered @event)
    {
        var itemId = @event.AssessmentItemId;
        var assessmentMastery = AssessmentMasteries.Find(am => am.AssessmentItemId == itemId);
        if (assessmentMastery == null)
            throw new InvalidOperationException("No assessment mastery for item: " + itemId +". Were the masteries created and loaded correctly?");

        assessmentMastery.UpdateMastery(@event);
        UpdateMastery();
    }

    private void UpdateMastery()
    {
        Mastery = Math.Round(AssessmentMasteries.Sum(am => am.Mastery) / AssessmentMasteries.Count, 2);
        if (Mastery > 0.97) Mastery = 1; // Resolves rounding errors.
    }
}