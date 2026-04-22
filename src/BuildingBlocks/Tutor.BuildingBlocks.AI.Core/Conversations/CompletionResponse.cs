namespace Tutor.BuildingBlocks.AI.Core.Conversations;

/// <summary>
/// Response from an AI completion request.
/// </summary>
public record CompletionResponse
{
    public required string Content { get; init; }
    public required TokenUsage Usage { get; init; }

    /// <summary>
    /// Why the model stopped generating (e.g., "stop", "length", "content_filter").
    /// </summary>
    public string? FinishReason { get; init; }
}

public record TokenUsage(int PromptTokens, int CompletionTokens)
{
    public int TotalTokens => PromptTokens + CompletionTokens;

    public TokenUsage Subtract(TokenUsage other) =>
        new(PromptTokens - other.PromptTokens, CompletionTokens - other.CompletionTokens);
}
