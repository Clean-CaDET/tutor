using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.Courses.Core.Domain.TokenWallet.Events;

public abstract class WalletEvent : DomainEvent
{
    public int LearnerId { get; set; }
    public int CourseId { get; set; }
}
