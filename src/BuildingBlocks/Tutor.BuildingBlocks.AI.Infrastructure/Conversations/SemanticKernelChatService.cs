using FluentResults;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Conversations;

/// <summary>
/// Semantic Kernel implementation of chat completion service.
/// </summary>
public class SemanticKernelChatService : IAiChatService
{
    private readonly IChatCompletionService _chatCompletionService;
    private readonly ITurnUsageTracker _usageTracker;

    public SemanticKernelChatService(Kernel kernel, ITurnUsageTracker usageTracker)
    {
        _chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        _usageTracker = usageTracker;
    }

    public async Task<Result<CompletionResponse>> CompleteAsync(CompletionRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var chatHistory = BuildChatHistory(request);
            var executionSettings = BuildExecutionSettings(request, streaming: false);

            var result = await _chatCompletionService.GetChatMessageContentAsync(chatHistory, executionSettings, cancellationToken: cancellationToken);
            var usage = TryExtractTokenUsage(result.Metadata) ?? new TokenUsage(0, 0);
            _usageTracker.Add(usage);

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
        var executionSettings = BuildExecutionSettings(request, streaming: true);

        TokenUsage? capturedUsage = null;
        try
        {
            await foreach (var chunk in _chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory, executionSettings, cancellationToken: cancellationToken))
            {
                var chunkUsage = TryExtractTokenUsage(chunk.Metadata);
                if (chunkUsage is not null) capturedUsage = chunkUsage;

                if (!string.IsNullOrEmpty(chunk.Content))
                    yield return chunk.Content;
            }
        }
        finally
        {
            if (capturedUsage is not null) _usageTracker.Add(capturedUsage);
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

    private static PromptExecutionSettings? BuildExecutionSettings(CompletionRequest request, bool streaming)
    {
        bool hasSettings = streaming || request.MaxTokens is not null
            || request.Temperature is not null || request.ReasoningEffort is not null;
        if (!hasSettings) return null;

        var settings = new OpenAIPromptExecutionSettings
        {
            MaxTokens = request.MaxTokens ?? 4096,
            ReasoningEffort = request.ReasoningEffort
        };

        if (streaming)
            settings.ExtensionData = new Dictionary<string, object>
            {
                ["stream_options"] = new Dictionary<string, object> { ["include_usage"] = true }
            };

        return settings;
    }

    private static TokenUsage? TryExtractTokenUsage(IReadOnlyDictionary<string, object?>? metadata)
    {
        if (metadata is null) return null;
        if (!metadata.TryGetValue("Usage", out var usage) || usage is null) return null;

        var usageType = usage.GetType();
        var inputTokensProperty = usageType.GetProperty("InputTokenCount") ?? usageType.GetProperty("PromptTokens");
        var outputTokensProperty = usageType.GetProperty("OutputTokenCount") ?? usageType.GetProperty("CompletionTokens");

        var promptTokens = inputTokensProperty?.GetValue(usage) is int input ? input : 0;
        var completionTokens = outputTokensProperty?.GetValue(usage) is int output ? output : 0;

        if (promptTokens == 0 && completionTokens == 0) return null;
        return new TokenUsage(promptTokens, completionTokens);
    }
}
