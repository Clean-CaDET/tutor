using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Web.Controllers.Events
{
    public class EventDTO
    {
        public DomainEvent DomainEvent { get; set; }
        public string Type { get; set; }

        public EventDTO(DomainEvent @event)
        {
            DomainEvent = @event;
            Type = @event.GetType().Name;
        }
    }
}
