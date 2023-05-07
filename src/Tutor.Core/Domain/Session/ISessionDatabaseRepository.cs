using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.Domain.Session;

public interface ISessionDatabaseRepository
{
    IEnumerable<DomainEvent> GetLaunchedSessions(int learnerId);
    IEnumerable<DomainEvent> GetFinishedSessions(int learnerId);
    IEnumerable<DomainEvent> GetEventsForSession(int learnerId, DateTime start, DateTime end);
}