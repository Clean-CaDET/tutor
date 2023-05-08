using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;

namespace Tutor.Core.Domain.Session;

public interface ISessionDatabaseRepository
{
    IEnumerable<SessionLaunched> GetSessionLaunchedEvents(int learnerId);
    IEnumerable<DomainEvent> GetEventsForSession(int learnerId, DateTime start, DateTime end);
    DomainEvent GetSessionFinishedEvent(int learnerId, KnowledgeComponentEvent domainEvent);
}