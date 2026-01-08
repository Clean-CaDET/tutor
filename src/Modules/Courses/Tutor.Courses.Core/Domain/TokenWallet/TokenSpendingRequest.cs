namespace Tutor.Courses.Core.Domain.TokenWallet;

public record TokenSpendingRequest(
    int UnitId,
    int PromptTokens,
    int CompletionTokens,
    AiFeatureType FeatureType,
    int? EntityId,
    string? PromptSummary
)
{
    public int TotalTokens => PromptTokens + CompletionTokens;
}

public record TokenSpendingResult(int RemainingBalance);
