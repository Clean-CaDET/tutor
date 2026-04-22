using System.Text;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Summary;

public class SummaryAgent : StreamingAgent, ISummaryAgent
{
    public SummaryAgent(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger<SummaryAgent> logger)
        : base(chatService, usageTracker, logger) { }

    public async Task<Result<string>> SummarizeAsync(
        ConversationAttempt attempt, ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = SummaryPromptBuilder.BuildSystemPrompt(attempt, task);
        var transcript = SummaryPromptBuilder.BuildTranscript(attempt);

        var buffer = new StringBuilder();
        await foreach (var chunk in StreamAsync(systemPrompt, transcript, maxTokens: 256, temperature: 0.5, ct))
        {
            switch (chunk)
            {
                case StreamToken token:
                    buffer.Append(token.Content);
                    break;
                case StreamFailure failure:
                    return Result.Fail<string>(failure.Reason);
            }
        }

        return buffer.Length > 0
            ? Result.Ok(buffer.ToString())
            : Result.Fail<string>("Summary generation failed.");
    }
}
