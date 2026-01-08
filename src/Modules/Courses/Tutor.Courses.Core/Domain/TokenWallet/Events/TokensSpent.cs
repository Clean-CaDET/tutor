namespace Tutor.Courses.Core.Domain.TokenWallet.Events;

public class TokensSpent : WalletEvent
{
    public int UnitId { get; set; }
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }
    public int TotalTokens => PromptTokens + CompletionTokens;
    public AiFeatureType FeatureType { get; set; }
    public int? EntityId { get; set; }
    public string? PromptSummary { get; set; }
}
