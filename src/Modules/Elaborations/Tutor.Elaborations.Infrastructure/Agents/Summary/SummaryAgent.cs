using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Summary;

public class SummaryAgent : StructuredAgent, ISummaryAgent
{
    public SummaryAgent(IAiChatService chatService, ILogger<SummaryAgent> logger)
        : base(chatService, logger) { }

    public Task<Result<string>> SummarizeAsync(
        ConversationAttempt attempt, ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = SummaryPromptBuilder.BuildSystemPrompt(attempt, task);
        var transcript = SummaryPromptBuilder.BuildTranscript(attempt);
        return CompleteTextAsync(
            systemPrompt, transcript, maxTokens: 256, temperature: 0.5,
            failureMessage: "Summary generation failed.", ct);
    }
}
