namespace Tutor.Stakeholders.Core.Domain.Events;

public class TokensDeducted : WalletEvent
{
    public int Amount { get; set; }
}