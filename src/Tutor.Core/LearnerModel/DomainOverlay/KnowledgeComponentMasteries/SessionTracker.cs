using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class SessionTracker : EventSourcedEntity
    {
        public TimeSpan DurationOfPreviousSessions { get; private set; } = new TimeSpan(0);
        public TimeSpan DurationOfCurrentSession { get => HasActiveSession ? LastActivity.Value - StartOfCurrentSession.Value : new TimeSpan(0); }
        public bool HasActiveSession { get => StartOfCurrentSession.HasValue; }
        public DateTime? StartOfCurrentSession { get; private set; }
        public DateTime? LastActivity { get; private set; }

        public void Launch()
        {
            if (HasActiveSession) Causes(new SessionAbandoned());

            Causes(new SessionLaunched());
        }

        public Result Terminate()
        {
            if (!HasActiveSession) return Result.Fail("No active session to terminate.");

            Causes(new SessionTerminated());
            return Result.Ok();
        }

        public Result Abandon()
        {
            if (!HasActiveSession) return Result.Fail("No active session to abandon.");

            Causes(new SessionAbandoned());
            return Result.Ok();
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        private void When(SessionLaunched @event)
        {
            StartOfCurrentSession = @event.TimeStamp;
            LastActivity = @event.TimeStamp;

            @event.DurationOfPreviousSessions = DurationOfPreviousSessions;
            @event.DurationOfCurrentSession = DurationOfCurrentSession;
        }

        private void When(SessionTerminated @event)
        {
            LastActivity = @event.TimeStamp;

            @event.DurationOfPreviousSessions = DurationOfPreviousSessions;
            @event.DurationOfCurrentSession = DurationOfCurrentSession;

            DurationOfPreviousSessions += DurationOfCurrentSession;
            StartOfCurrentSession = null;
            LastActivity = null;
        }

        private void When(SessionAbandoned @event)
        {
            @event.DurationOfPreviousSessions = DurationOfPreviousSessions;
            @event.DurationOfCurrentSession = DurationOfCurrentSession;

            DurationOfPreviousSessions += DurationOfCurrentSession;
            StartOfCurrentSession = null;
            LastActivity = null;
        }

        private void When(KnowledgeComponentEvent @event)
        {
            LastActivity = @event.TimeStamp;

            @event.DurationOfPreviousSessions = DurationOfPreviousSessions;
            @event.DurationOfCurrentSession = DurationOfCurrentSession;
        }
    }
}
