using System.Collections.Generic;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class EventSourcedAggregateRoot
    {
        private readonly List<DomainEvent> _events = new List<DomainEvent>();

        public IEnumerable<DomainEvent> GetUncommittedEvents()
        {
            return _events;
        }

        public void MarkEventsAsCommitted()
        {
            _events.Clear();
        }

        public void LoadFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var @event in history) Apply(@event);
        }

        protected void Causes(DomainEvent @event)
        {
            _events.Add(@event);
            Apply(@event);
        }

        protected abstract void Apply(DomainEvent @event);
    }
}
