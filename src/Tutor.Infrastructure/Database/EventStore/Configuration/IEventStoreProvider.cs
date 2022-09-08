namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public interface IEventStoreProvider
    {
        IEventStore GetEventStore(IEventSerializer serializer);
    }
}
