namespace Tutor.BuildingBlocks.AI.Core.Conversations;

public record CompletionRequest
{
    public required IReadOnlyList<ChatMessage> Messages { get; init; }
    public string? SystemPrompt { get; init; }
    public int? MaxTokens { get; init; }
    public double? Temperature { get; init; }

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
