using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.SessionLifecycleEvents;
using Tutor.Core.Domain.Session;

namespace Tutor.Infrastructure.Database.Repositories.Session;

public class SessionDatabaseRepository : ISessionDatabaseRepository
{
    private readonly IEventStore _eventStore;
    
    public SessionDatabaseRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    public IEnumerable<SessionLaunched> GetSessionLaunchedEvents(int learnerId)
    {
        var result = _eventStore.Events.Where(e =>
            e.RootElement.GetProperty("$discriminator").GetString() == "SessionLaunched"
            && e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList<SessionLaunched>();
        return result;
    }

    public DomainEvent GetSessionFinishedEvent(int learnerId, KnowledgeComponentEvent domainEvent)
    {
        var result = _eventStore.Events.Where(e =>
            (e.RootElement.GetProperty("$discriminator").GetString() == "SessionTerminated"
             || e.RootElement.GetProperty("$discriminator").GetString() == "SessionAbandoned")
            && e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId
            && e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == domainEvent.KnowledgeComponentId).After(
            domainEvent.TimeStamp).ToList().FirstOrDefault();
        return result;
    }

    public IEnumerable<DomainEvent> GetEventsForSession(int learnerId, DateTime start, DateTime end)
    {
        var result = _eventStore.Events.Where(e =>
            (start - e.RootElement.GetProperty("TimeStamp").GetDateTime()).TotalSeconds - 1 <= 0
            && (end - e.RootElement.GetProperty("TimeStamp").GetDateTime()).TotalSeconds + 1 >= 0
            && e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList();
        return result;
    }
}