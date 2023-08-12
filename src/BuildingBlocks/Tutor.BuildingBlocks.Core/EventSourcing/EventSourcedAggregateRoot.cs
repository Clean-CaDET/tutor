using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.BuildingBlocks.Core.EventSourcing;

public abstract class EventSourcedAggregateRoot : AggregateRoot
{
    private readonly List<DomainEvent> _changes = new();

    /// <summary>
    /// Initialized the aggregate for event sourcing.
    /// </summary>
    /// <remarks>
    /// Override if the aggregate contains <see cref="EventSourcedEntity"/> objects which need to be initialized. 
    /// </remarks>
    public virtual void Initialize() { }

    /// <returns>Events recorded since aggregate construction or last call to <see cref="ClearChanges"/>.</returns>
    public IEnumerable<DomainEvent> GetChanges()
    {
        return _changes;
    }

    /// <summary>
    /// Clears recorded events.
    /// </summary>
    public void ClearChanges()
    {
        _changes.Clear();
    }

    /// <summary>
    /// Applies events to aggregate. 
    /// </summary>
    /// <param name="history">Must be sorted chronologically and valid in the aggregate's current state.</param>
    public void LoadFromHistory(IEnumerable<DomainEvent> history)
    {
        foreach (var @event in history)
        {
            Apply(@event);
        }
    }

    /// <summary>
    /// Records the event and forwards it to <see cref="Apply(DomainEvent)"/>.
    /// </summary>
    /// <remarks>
    /// This method should be called from the aggregate's command methods if invariants are satisfied 
    /// and the aggregate state needs to be changed.
    /// </remarks>
    /// <param name="event">Must be valid in the aggregate's current state.</param>
    protected internal void Causes(DomainEvent @event)
    {
        _changes.Add(@event);
        Apply(@event);
    }

    /// <summary>
    /// Applies changes represented by an event to the aggregate. 
    /// </summary>
    /// <remarks>
    /// Changes to aggregate state should happen exclusively in this method.
    /// Implementation should assume that the event is valid and apply changes without checking invariants. 
    /// This method should always be called through <see cref="Causes(DomainEvent)"/>.
    /// </remarks>
    /// <param name="event"></param>
    protected abstract void Apply(DomainEvent @event);
}