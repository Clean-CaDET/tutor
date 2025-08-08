namespace Tutor.Stakeholders.Core.Domain.Events;

public class TokensAdded : WalletEvent
{
    public int Amount { get; set; }
}