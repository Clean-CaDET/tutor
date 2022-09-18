using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class EventSourcedEntity : Entity
    {
        private EventSourcedAggregateRoot _root;

        public virtual void Initialize(EventSourcedAggregateRoot root)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
        }

        protected void Causes(DomainEvent @event)
        {
            if (_root == null)
                throw new EventSourcingException("Entity of type " + GetType() + " not initialized for Event Sourcing.");
            _root.Causes(@event);
        }

        public abstract void Apply(DomainEvent @event);
    }
}
