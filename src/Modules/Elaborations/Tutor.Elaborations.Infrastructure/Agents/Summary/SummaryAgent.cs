using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Summary;

public class SummaryAgent : ISummaryAgent
{
    private readonly IAiChatService _chatService;

    public SummaryAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<Result<string>> SummarizeAsync(ConversationAttempt attempt,
        ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = SummaryPromptBuilder.BuildSystemPrompt(attempt, task);
        var transcript = SummaryPromptBuilder.BuildTranscript(attempt);

        var request = CompletionRequest.SingleMessage(transcript, systemPrompt, maxTokens: 256, temperature: 0.5);

        var result = await _chatService.CompleteAsync(request, ct);
        return result.IsSuccess
            ? Result.Ok(result.Value.Content)
            : Result.Fail("Summary generation failed.");
    }
}
