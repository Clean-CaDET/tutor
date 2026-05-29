namespace Tutor.BuildingBlocks.AI.Core.Conversations;

/// <summary>
/// Request for generating an AI completion.
/// </summary>
public record CompletionRequest
{
    public required IReadOnlyList<ChatMessage> Messages { get; init; }
    public string? SystemPrompt { get; init; }
    public int? MaxTokens { get; init; }

    /// <summary>
    /// Controls randomness (0.0 to 2.0). Higher values make output more random, lower values more deterministic.
    /// </summary>
    public double? Temperature { get; init; }

    /// <summary>
    /// Controls reasoning depth ("low", "medium", "high"). When set, Temperature is ignored.
    /// </summary>
    public string? ReasoningEffort { get; init; }

    /// <summary>
    /// Optional metadata for passing context to decorators or middleware.
    /// </summary>
    public IReadOnlyDictionary<string, object>? Metadata { get; init; }

    public static CompletionRequest Create(IEnumerable<ChatMessage> messages, string? systemPrompt, int? maxTokens, double? temperature)
    {
        return new CompletionRequest
        {
            Messages = messages.ToList(),
            SystemPrompt = systemPrompt,
            MaxTokens = maxTokens,
            Temperature = temperature
        };
    }

    public static CompletionRequest SingleMessage(string userMessage, string? systemPrompt, int? maxTokens, double? temperature)
    {
        return new CompletionRequest
        {
            Messages = [ChatMessage.FromUser(userMessage)],
            SystemPrompt = systemPrompt,
            MaxTokens = maxTokens,
            Temperature = temperature
        };
    }
}
