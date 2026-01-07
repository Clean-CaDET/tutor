namespace Tutor.BuildingBlocks.AI.Core.Conversations;

public record CompletionResponse
{
    public required string Content { get; init; }
    public required TokenUsage Usage { get; init; }
    public string? FinishReason { get; init; }
}

public record TokenUsage(int PromptTokens, int CompletionTokens)
{
    public int TotalTokens => PromptTokens + CompletionTokens;
}
