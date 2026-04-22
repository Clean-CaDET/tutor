using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.MetaHelp;

public class MetaHelpAgent : StreamingAgent, IMetaHelpAgent
{
    public MetaHelpAgent(IAiChatService chatService) : base(chatService) { }

    public IAsyncEnumerable<StreamOutput> StreamAsync(
        ConceptElaborationTask task, string progressLine, ProbeDirective? nextTarget,
        CancellationToken ct)
    {
        var systemPrompt = MetaHelpPromptBuilder.BuildSystemPrompt(task, progressLine, nextTarget);
        var userMessage = MetaHelpPromptBuilder.BuildUserMessage();
        return StreamAsync(systemPrompt, userMessage, maxTokens: 256, temperature: 0.5, ct);
    }
}
