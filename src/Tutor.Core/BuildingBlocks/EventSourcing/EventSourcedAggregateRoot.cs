using System.Collections.Generic;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class EventSourcedAggregateRoot : AggregateRoot
    {
        private readonly List<DomainEvent> _changes = new();

        public virtual void Initialize() { }

        public IEnumerable<DomainEvent> GetChanges()
        {
            return _changes;
        }

        public void ClearChanges()
        {
            _changes.Clear();
        }

        public void LoadFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var @event in history)
            {
                Apply(@event);
            }
        }

        protected internal void Causes(DomainEvent @event)
        {
            _changes.Add(@event);
            Apply(@event);
        }

        protected abstract void Apply(DomainEvent @event);
    }
}
