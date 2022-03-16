using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Web.Controllers.Events
{
    public class EventDto
    {
        public DomainEvent DomainEvent { get; set; }
        public string Type { get; set; }

        public EventDto(DomainEvent @event)
        {
            DomainEvent = @event;
            Type = @event.GetType().Name;
        }
    }
}
