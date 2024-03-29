﻿using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

public class SessionTracker : EventSourcedEntity
{
    public int CountOfSessions { get; private set; }
    public TimeSpan DurationOfAllSessions => DurationOfFinishedSessions + DurationOfUnfinishedSession.GetValueOrDefault();
    public TimeSpan DurationOfFinishedSessions { get; private set; } = new(0);
    public bool HasUnfinishedSession => StartOfUnfinishedSession.HasValue;

    public TimeSpan? DurationOfUnfinishedSession => HasUnfinishedSession ? DateTime.UtcNow - StartOfUnfinishedSession!.Value : TimeSpan.Zero;
    public DateTime? StartOfUnfinishedSession { get; private set; }

    public bool IsPaused { get; private set; }
    public TimeSpan DurationOfAllPauses => DurationOfFinishedPauses + DurationOfUnfinishedPause.GetValueOrDefault();
    public TimeSpan DurationOfFinishedPauses { get; private set; } = new(0);
    public TimeSpan? DurationOfUnfinishedPause => IsPaused ? DateTime.UtcNow - UnfinishedPauseStart!.Value : TimeSpan.Zero;
    public DateTime? UnfinishedPauseStart { get; private set; }

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
        if (!HasUnfinishedSession) Launch();
        if (IsPaused) return Result.Fail("Session is already paused.");
        
        IsPaused = true;
        var sessionPausedEvent = new SessionPaused();
        sessionPausedEvent.TimeStamp = sessionPausedEvent.TimeStamp.AddMinutes(-2);
        Causes(sessionPausedEvent);
        return Result.Ok();
    }

    public Result Continue()
    {
        if (!HasUnfinishedSession) Launch();
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
        UnfinishedPauseStart = @event.TimeStamp;
    }

    private void When(SessionContinued @event)
    {
        DurationOfFinishedPauses += @event.TimeStamp - UnfinishedPauseStart!.Value;
        UnfinishedPauseStart = null;
    }

    private void When(SessionAbandoned @event)
    {
        DurationOfFinishedSessions += DurationOfUnfinishedSession.GetValueOrDefault();
        StartOfUnfinishedSession = null;
    }

    private void When(KnowledgeComponentCompleted @event)
    {
        @event.MinutesToCompletion = DurationOfAllSessions.TotalMinutes - DurationOfAllPauses.TotalMinutes;
    }

    private void When(KnowledgeComponentPassed @event)
    {
        @event.MinutesToPass = DurationOfAllSessions.TotalMinutes - DurationOfAllPauses.TotalMinutes;
    }

    private void When(KnowledgeComponentSatisfied @event)
    {
        @event.MinutesToSatisfaction = DurationOfAllSessions.TotalMinutes - DurationOfAllPauses.TotalMinutes;
    }

    private static void When(KnowledgeComponentEvent @event)
    {
        // LastActivity is no longer being recorded.
    }
}