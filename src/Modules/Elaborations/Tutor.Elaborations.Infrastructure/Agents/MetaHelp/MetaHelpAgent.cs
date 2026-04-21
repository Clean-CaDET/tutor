using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.MetaHelp;

public class MetaHelpAgent : IMetaHelpAgent
{
    private readonly IAiChatService _chatService;

    public MetaHelpAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        ConceptElaborationTask task, string progressLine, ProbeDirective? nextTarget,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = MetaHelpPromptBuilder.BuildSystemPrompt(task, progressLine, nextTarget);
        var userMessage = MetaHelpPromptBuilder.BuildUserMessage();
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 256, temperature: 0.5);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
