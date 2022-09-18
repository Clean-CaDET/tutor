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
            if (HasActiveSession) Causes(new SessionAbandoned()
            {
                DurationOfCurrentSession = DurationOfCurrentSession,
                DurationOfPreviousSessions = DurationOfPreviousSessions
            });

            Causes(new SessionLaunched()
            {
                DurationOfPreviousSessions = DurationOfPreviousSessions
            });
        }

        public Result Terminate()
        {
            if (!HasActiveSession) return Result.Fail("No active session to terminate.");

            Causes(new SessionTerminated()
            {
                DurationOfCurrentSession = DurationOfCurrentSession,
                DurationOfPreviousSessions = DurationOfPreviousSessions
            });
            return Result.Ok();
        }

        public Result Abandon()
        {
            if (!HasActiveSession) return Result.Fail("No active session to abandon.");

            Causes(new SessionAbandoned()
            {
                DurationOfCurrentSession = DurationOfCurrentSession,
                DurationOfPreviousSessions = DurationOfPreviousSessions
            });
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
        }

        private void When(SessionTerminated @event)
        {
            LastActivity = @event.TimeStamp;
            DurationOfPreviousSessions += DurationOfCurrentSession;
            StartOfCurrentSession = null;
            LastActivity = null;
        }

        private void When(SessionAbandoned @event)
        {
            DurationOfPreviousSessions += DurationOfCurrentSession;
            StartOfCurrentSession = null;
            LastActivity = null;
        }

        private void When(KnowledgeComponentEvent @event)
        {
            LastActivity = @event.TimeStamp;
        }
    }
}
