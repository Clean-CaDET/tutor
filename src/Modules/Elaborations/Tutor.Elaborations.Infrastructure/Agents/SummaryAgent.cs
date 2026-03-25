using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Infrastructure.Agents.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class SummaryAgent : ISummaryAgent
{
    private readonly IAiChatService _chatService;

    public SummaryAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<Result<string>> SummarizeAsync(ConversationAttempt attempt,
        ConceptRecord conceptRecord, CancellationToken ct)
    {
        var systemPrompt = SummaryPromptBuilder.BuildSystemPrompt(attempt, conceptRecord);
        var transcript = SummaryPromptBuilder.BuildTranscript(attempt);

        var request = CompletionRequest.SingleMessage(transcript, systemPrompt, maxTokens: 256, temperature: 0.5);

        var result = await _chatService.CompleteAsync(request, ct);
        return result.IsSuccess
            ? Result.Ok(result.Value.Content)
            : Result.Fail("Summary generation failed.");
    }
}
