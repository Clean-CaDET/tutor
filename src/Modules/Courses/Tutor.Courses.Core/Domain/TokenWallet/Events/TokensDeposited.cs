namespace Tutor.Courses.Core.Domain.TokenWallet.Events;

public class TokensDeposited : WalletEvent
{
    public int Amount { get; set; }
    public string Reason { get; set; } = string.Empty;
}
