namespace Tutor.Courses.Core.Domain.TokenWallet.Events;

public class TokenSpendingBlocked : WalletEvent
{
    public int UnitId { get; set; }
    public int RequestedTokens { get; set; }
    public AiFeatureType FeatureType { get; set; }
    public string BlockReason { get; set; } = string.Empty;
}
