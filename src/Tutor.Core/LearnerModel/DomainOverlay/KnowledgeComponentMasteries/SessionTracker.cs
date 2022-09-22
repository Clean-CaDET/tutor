using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class SessionTracker : EventSourcedEntity
    {
        public int CountOfSessions { get; private set; } = 0;
        public TimeSpan DurationOfAllSessions { get => DurationOfFinishedSessions + DurationOfUnfinishedSession.GetValueOrDefault(); }
        public TimeSpan DurationOfFinishedSessions { get; private set; } = new TimeSpan(0);
        public bool HasUnfinishedSession { get => StartOfUnfinishedSession.HasValue; }
        public TimeSpan? DurationOfUnfinishedSession
        { get => HasUnfinishedSession ? LastActivity.Value - StartOfUnfinishedSession.Value : null; }
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
            @event.MinutesToCompletion = DurationOfAllSessions.TotalMinutes;
            LastActivity = @event.TimeStamp;
        }

        private void When(KnowledgeComponentPassed @event)
        {
            @event.MinutesToPass = DurationOfAllSessions.TotalMinutes;
            LastActivity = @event.TimeStamp;
        }

        private void When(KnowledgeComponentSatisfied @event)
        {
            @event.MinutesToSatisfaction = DurationOfAllSessions.TotalMinutes;
            LastActivity = @event.TimeStamp;
        }

        private void When(KnowledgeComponentEvent @event)
        {
            LastActivity = @event.TimeStamp;
        }
    }
}
