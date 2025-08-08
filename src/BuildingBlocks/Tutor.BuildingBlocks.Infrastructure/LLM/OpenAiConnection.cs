using FluentResults;
using OpenAI.Chat;
using Tutor.BuildingBlocks.Core.LLM;

namespace Tutor.BuildingBlocks.Infrastructure.LLM;

public class OpenAiConnection : ILlmConnection
{
    private readonly ChatClient _client;

    public OpenAiConnection(ChatClient client) => _client = client;

    public async Task<Result<LlmResponse>> CompleteAsync(List<LlmMessage> req)
    {
        var messages = CreateChatMessages(req);

        var completion = await _client.CompleteChatAsync(messages);
        var result = completion.Value;

        var text = result.Content.Count > 0 ? result.Content[0].Text : string.Empty;
        var usage = result.Usage;
        return new LlmResponse(
            Message: new LlmMessage(text, (AiRole)result.Role, new DateTime()),
            PromptTokens: usage?.InputTokenCount,
            CompletionTokens: usage?.OutputTokenCount,
            FinishReason: result.FinishReason.ToString());
    }

    private static List<ChatMessage> CreateChatMessages(List<LlmMessage> req)
    {
        var messages = req.Select<LlmMessage, ChatMessage>(m =>
        {
            return m.Role switch
            {
                AiRole.System => new SystemChatMessage(m.Content),
                AiRole.User => new UserChatMessage(m.Content),
                _ => new AssistantChatMessage(m.Content)
            };
        }).ToList();
        return messages;
    }
}