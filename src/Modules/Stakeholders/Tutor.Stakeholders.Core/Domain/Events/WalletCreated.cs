namespace Tutor.Stakeholders.Core.Domain.Events;

public class WalletCreated : WalletEvent
{
    public int InitialTokens { get; set; }
}