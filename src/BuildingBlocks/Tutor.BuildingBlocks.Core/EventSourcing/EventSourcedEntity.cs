using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.BuildingBlocks.Core.EventSourcing;

public abstract class EventSourcedEntity : Entity
{
    private EventSourcedAggregateRoot _root;

    /// <summary>
    /// Initializes the entity for event sourcing. 
    /// </summary>
    /// <remarks>
    /// Override if the entity contains other <see cref="EventSourcedEntity"/> objects which needs to be initialized. 
    /// This method should only be invoked from 
    /// <see cref="EventSourcedAggregateRoot.Initialize"/> (for entities contained by the aggregate root)
    /// or <see cref="Initialize(EventSourcedAggregateRoot)"/> (for entities contained by other entities).
    /// </remarks>
    /// <param name="root"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual void Initialize(EventSourcedAggregateRoot root)
    {
        _root = root ?? throw new ArgumentNullException(nameof(root));
    }

    /// <summary>
    /// Forwards the event to <see cref="EventSourcedAggregateRoot.Causes(DomainEvent)"/> to be recorded and applied
    /// to the aggregate.
    /// </summary>
    /// <remarks>
    /// This method should be called from the entity's command methods if invariants are satisfied 
    /// and the aggregate state needs to be changed.
    /// </remarks>
    /// <param name="event">Must be valid in the entity's current state.</param>
    /// <exception cref="EventSourcingException"></exception>
    protected void Causes(DomainEvent @event)
    {
        if (_root == null)
            throw new EventSourcingException("Entity of type " + GetType() + " not initialized for Event Sourcing.");
        _root.Causes(@event);
    }

    /// <summary>
    /// Applies changes represented by an event to the entity.
    /// </summary>
    /// <remarks>
    /// Changes to entity state should happen exclusively in this method.
    /// Implementation should assume that the event is valid and apply changes without checking invariants. 
    /// This method should only be invoked from 
    /// <see cref="EventSourcedAggregateRoot.Apply(DomainEvent)"/> (for entities contained by the aggregate root) 
    /// or <see cref="Apply(DomainEvent)"/> (for entities contained by other entities).
    /// </remarks>
    /// <param name="event"></param>
    public abstract void Apply(DomainEvent @event);
}