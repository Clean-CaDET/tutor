using FluentResults;
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

    public DateTime? LastActivity { get; private set; }

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

            var sessionAbandoned = new SessionAbandoned();

            if (LastActivity.HasValue && (sessionAbandoned.TimeStamp - LastActivity.Value).TotalHours > 1)
            {
                sessionAbandoned.TimeStamp = LastActivity.Value;
            }

            Causes(sessionAbandoned);
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
        if (IsPaused) return Result.Ok();
        
        var sessionPausedEvent = new SessionPaused();

        if (LastActivity.HasValue && (sessionPausedEvent.TimeStamp - LastActivity.Value).TotalHours > 1)
        {
            sessionPausedEvent.TimeStamp = LastActivity.Value;
        }
        else
        {
            sessionPausedEvent.TimeStamp = sessionPausedEvent.TimeStamp.AddMinutes(-2);
        }

        Causes(sessionPausedEvent);
        return Result.Ok();
    }

    public Result Continue()
    {
        if (!HasUnfinishedSession) return Result.Fail("No active session to continue.");
        if (!IsPaused) return Result.Ok();
            
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
        LastActivity = @event.TimeStamp;
        StartOfUnfinishedSession = @event.TimeStamp;
        CountOfSessions++;
    }

    private void When(SessionTerminated @event)
    {
        DurationOfFinishedSessions += DurationOfUnfinishedSession.GetValueOrDefault();
        StartOfUnfinishedSession = null;
        LastActivity = null;
    }

    private void When(SessionPaused @event)
    {
        IsPaused = true;
        UnfinishedPauseStart = @event.TimeStamp;
    }

    private void When(SessionContinued @event)
    {
        IsPaused = false;
        LastActivity = @event.TimeStamp;
        DurationOfFinishedPauses += @event.TimeStamp - UnfinishedPauseStart!.Value;
        UnfinishedPauseStart = null;
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
        @event.MinutesToCompletion = DurationOfAllSessions.TotalMinutes - DurationOfAllPauses.TotalMinutes;
    }

    private void When(KnowledgeComponentPassed @event)
    {
        LastActivity = @event.TimeStamp;
        @event.MinutesToPass = DurationOfAllSessions.TotalMinutes - DurationOfAllPauses.TotalMinutes;
    }

    private void When(KnowledgeComponentSatisfied @event)
    {
        LastActivity = @event.TimeStamp;
        @event.MinutesToSatisfaction = DurationOfAllSessions.TotalMinutes - DurationOfAllPauses.TotalMinutes;
    }

    private void When(KnowledgeComponentEvent @event)
    {
        LastActivity = @event.TimeStamp;
    }
}