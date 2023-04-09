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

    public TimeSpan? DurationOfUnfinishedSession => HasUnfinishedSession ? DateTime.UtcNow - StartOfUnfinishedSession.Value : null;
    public DateTime? StartOfUnfinishedSession { get; private set; }

    public bool IsPaused { get; private set; }
    public TimeSpan DurationOfAllPauses => DurationOfFinishedPauses + DurationOfUnfinishedPauses.GetValueOrDefault();
    public TimeSpan DurationOfFinishedPauses { get; private set; } = new(0);
    public TimeSpan? DurationOfUnfinishedPauses => IsPaused ? DateTime.UtcNow - LastPause.Value : null;
    public DateTime? LastPause { get; private set; }

    public void Launch()
    {
        if (HasUnfinishedSession)
        {
            if (IsPaused) Continue();
            Causes(new SessionAbandoned());
        }
        
        Causes(new SessionLaunched());
    }

    public Result Terminate()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to terminate.");
        if (IsPaused) Continue();

            Causes(new SessionTerminated());
        return Result.Ok();
    }

    public Result Pause()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to pause.");
        if (IsPaused) return Result.Fail("Session is already paused.");
        
        IsPaused = true;
        Causes(new SessionPaused());
        return Result.Ok();
    }

    public Result Continue()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to continue.");
        if (!IsPaused) return Result.Fail("Session is not paused.");
            
        IsPaused = false;
        Causes(new SessionContinued());
        return Result.Ok();
    }

    public Result Abandon()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to abandon.");
        if (IsPaused) Continue();

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
        CountOfSessions++;
    }

    private void When(SessionTerminated @event)
    {
        DurationOfFinishedSessions += DurationOfUnfinishedSession.GetValueOrDefault();
        StartOfUnfinishedSession = null;
    }

    private void When(SessionPaused @event)
    {
        LastPause = @event.TimeStamp;
    }

    private void When(SessionContinued @event)
    {
        DurationOfFinishedPauses += @event.TimeStamp - LastPause.Value;
        LastPause = null;
    }

    private void When(SessionAbandoned @event)
    {
        DurationOfFinishedSessions += DurationOfUnfinishedSession.GetValueOrDefault();
        StartOfUnfinishedSession = null;
    }

    private void When(KnowledgeComponentCompleted @event)
    {
        @event.MinutesToCompletion = DurationOfAllSessions.TotalMinutes;
    }

    private void When(KnowledgeComponentPassed @event)
    {
        @event.MinutesToPass = DurationOfAllSessions.TotalMinutes;
    }

    private void When(KnowledgeComponentSatisfied @event)
    {
        @event.MinutesToSatisfaction = DurationOfAllSessions.TotalMinutes;
    }

    private void When(KnowledgeComponentEvent @event)
    {
    }
}