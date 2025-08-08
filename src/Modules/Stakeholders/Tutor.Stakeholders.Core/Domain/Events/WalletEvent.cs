using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.Stakeholders.Core.Domain.Events;

public abstract class WalletEvent : DomainEvent
{
    public int LearnerId { get; set; }
}