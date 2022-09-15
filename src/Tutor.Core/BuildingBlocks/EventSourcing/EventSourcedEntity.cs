using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class EventSourcedEntity : Entity
    {
        private EventSourcedAggregateRoot _root;

        public void Initialize(EventSourcedAggregateRoot root)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        protected void Causes(DomainEvent @event)
        {
            _root.Causes(@event);
        }

        public abstract void Apply(DomainEvent @event);
    }
}
