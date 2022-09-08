namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public interface IEventSerializerProvider
    {
        IEventSerializer GetEventSerializer();
    }
}
