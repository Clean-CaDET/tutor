using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Scaffolding;

public class ScaffoldingAgent : StreamingAgent, IScaffoldingAgent
{
    public ScaffoldingAgent(IAiChatService chatService) : base(chatService) { }

    public IAsyncEnumerable<string> StreamAsync(
        ProbeDirective target, ConversationAttempt attempt, ConceptElaborationTask task,
        CancellationToken ct)
    {
        var systemPrompt = ScaffoldingPromptBuilder.BuildSystemPrompt(task, target);
        var userMessage = ScaffoldingPromptBuilder.BuildUserMessage(attempt);
        return StreamAsync(systemPrompt, userMessage, maxTokens: 512, temperature: 0.7, ct);
    }
}
