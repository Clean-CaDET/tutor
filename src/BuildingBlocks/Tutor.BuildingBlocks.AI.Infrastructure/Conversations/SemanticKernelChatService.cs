using FluentResults;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Conversations;

/// <summary>
/// Semantic Kernel implementation of chat completion service.
/// </summary>
public class SemanticKernelChatService : IAiChatService
{
    private readonly IChatCompletionService _chatCompletionService;

    public SemanticKernelChatService(Kernel kernel)
    {
        _chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
    }

    public async Task<Result<CompletionResponse>> CompleteAsync(CompletionRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var chatHistory = BuildChatHistory(request);
            var executionSettings = BuildExecutionSettings(request);

            var result = await _chatCompletionService.GetChatMessageContentAsync(chatHistory, executionSettings, cancellationToken: cancellationToken);
            var usage = ExtractTokenUsage(result);

            return Result.Ok(new CompletionResponse
            {
                Content = result.Content ?? string.Empty,
                Usage = usage,
                FinishReason = result.Metadata?.GetValueOrDefault("FinishReason")?.ToString()
            });
        }
        catch (Exception ex)
        {
            return Result.Fail<CompletionResponse>($"Chat completion failed: {ex.Message}");
        }
    }

    public async IAsyncEnumerable<string> StreamAsync(CompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var chatHistory = BuildChatHistory(request);
        var executionSettings = BuildExecutionSettings(request);

        await foreach (var chunk in _chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory, executionSettings, cancellationToken: cancellationToken))
        {
            if (!string.IsNullOrEmpty(chunk.Content))
            {
                yield return chunk.Content;
            }
        }
    }

    private static ChatHistory BuildChatHistory(CompletionRequest request)
    {
        var chatHistory = new ChatHistory();

        if (!string.IsNullOrWhiteSpace(request.SystemPrompt))
        {
            chatHistory.AddSystemMessage(request.SystemPrompt);
        }

        foreach (var message in request.Messages)
        {
            switch (message.Role)
            {
                case ChatRole.System:
                    chatHistory.AddSystemMessage(message.Content);
                    break;
                case ChatRole.User:
                    chatHistory.AddUserMessage(message.Content);
                    break;
                case ChatRole.Assistant:
                    chatHistory.AddAssistantMessage(message.Content);
                    break;
            }
        }

        return chatHistory;
    }

    private static PromptExecutionSettings? BuildExecutionSettings(CompletionRequest request)
    {
        if (request.MaxTokens is null && request.Temperature is null)
        {
            return null;
        }

        return new PromptExecutionSettings
        {
            ExtensionData = new Dictionary<string, object>
            {
                ["max_tokens"] = request.MaxTokens ?? 4096,
                ["temperature"] = request.Temperature ?? 0.7
            }
        };
    }

    private static TokenUsage ExtractTokenUsage(ChatMessageContent result)
    {
        var promptTokens = 0;
        var completionTokens = 0;

        if (result.Metadata?.TryGetValue("Usage", out var usage) == true && usage is not null)
        {
            var usageType = usage.GetType();
            var inputTokensProperty = usageType.GetProperty("InputTokenCount") ?? usageType.GetProperty("PromptTokens");
            var outputTokensProperty = usageType.GetProperty("OutputTokenCount") ?? usageType.GetProperty("CompletionTokens");

            if (inputTokensProperty?.GetValue(usage) is int input)
                promptTokens = input;
            if (outputTokensProperty?.GetValue(usage) is int output)
                completionTokens = output;
        }

        return new TokenUsage(promptTokens, completionTokens);
    }
}
