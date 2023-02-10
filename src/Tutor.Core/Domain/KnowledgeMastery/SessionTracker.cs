using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;

namespace Tutor.Core.Domain.KnowledgeMastery;

public class SessionTracker : EventSourcedEntity
{
    public int CountOfSessions { get; private set; }
    public TimeSpan DurationOfAllSessions => DurationOfFinishedSessions + DurationOfUnfinishedSession.GetValueOrDefault();
    public TimeSpan DurationOfFinishedSessions { get; private set; } = new(0);
    public bool HasUnfinishedSession => StartOfUnfinishedSession.HasValue;

    public TimeSpan? DurationOfUnfinishedSession => HasUnfinishedSession ? LastActivity.Value - StartOfUnfinishedSession.Value : null;
    public DateTime? StartOfUnfinishedSession { get; private set; }
    public DateTime? LastActivity { get; private set; }

    public void Launch()
    {
        if (HasUnfinishedSession) Causes(new SessionAbandoned());

        Causes(new SessionLaunched());
    }

    public Result Terminate()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to terminate.");

        Causes(new SessionTerminated());
        return Result.Ok();
    }

    public Result Abandon()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to abandon.");

        Causes(new SessionAbandoned());
        return Result.Ok();
    }

    public override void Apply(DomainEvent @event)
    {
        When((dynamic)@event);
    }

    private void When(SessionLaunched @event)
    {
        StartOfUnfinishedSession = @event.TimeStamp;
        LastActivity = @event.TimeStamp;
        CountOfSessions++;
    }

    private void When(SessionTerminated @event)
    {
        LastActivity = @event.TimeStamp;

        DurationOfFinishedSessions += DurationOfUnfinishedSession.GetValueOrDefault();
        StartOfUnfinishedSession = null;
        LastActivity = null;
    }

    private void When(SessionAbandoned @event)
    {
        DurationOfFinishedSessions += DurationOfUnfinishedSession.GetValueOrDefault();
        StartOfUnfinishedSession = null;
        LastActivity = null;
    }

    private void When(KnowledgeComponentCompleted @event)
    {
        LastActivity = @event.TimeStamp;
        @event.MinutesToCompletion = DurationOfAllSessions.TotalMinutes;
    }

    private void When(KnowledgeComponentPassed @event)
    {
        LastActivity = @event.TimeStamp;
        @event.MinutesToPass = DurationOfAllSessions.TotalMinutes;
    }

    private void When(KnowledgeComponentSatisfied @event)
    {
        LastActivity = @event.TimeStamp;
        @event.MinutesToSatisfaction = DurationOfAllSessions.TotalMinutes;
    }

    private void When(KnowledgeComponentEvent @event)
    {
        LastActivity = @event.TimeStamp;
    }
}