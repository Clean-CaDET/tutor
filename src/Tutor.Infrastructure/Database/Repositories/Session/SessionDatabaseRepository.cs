using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.Session;

namespace Tutor.Infrastructure.Database.Repositories.Session;

public class SessionDatabaseRepository : ISessionDatabaseRepository
{
    private readonly IEventStore _eventStore;
    
    public SessionDatabaseRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    public IEnumerable<DomainEvent> GetLaunchedSessions(int learnerId)
    {
        var result = _eventStore.Events.Where(e =>
            e.RootElement.GetProperty("$discriminator").GetString() == "SessionLaunched"
            && e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList();
        return result;
    }

    public IEnumerable<DomainEvent> GetFinishedSessions(int learnerId)
    {
        var result = _eventStore.Events.Where(e =>
            (e.RootElement.GetProperty("$discriminator").GetString() == "SessionTerminated" 
             || e.RootElement.GetProperty("$discriminator").GetString() == "SessionAbandoned")
            && e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList();
        return result;
    }

    public IEnumerable<DomainEvent> GetEventsForSession(int learnerId, DateTime start, DateTime end)
    {
        var result = _eventStore.Events.Where(e =>
            e.RootElement.GetProperty("TimeStamp").GetDateTime() >= start
            && e.RootElement.GetProperty("TimeStamp").GetDateTime() <= end
            && e.RootElement.GetProperty("LearnerId").GetInt32() == learnerId).ToList();
        return result;
    }
}