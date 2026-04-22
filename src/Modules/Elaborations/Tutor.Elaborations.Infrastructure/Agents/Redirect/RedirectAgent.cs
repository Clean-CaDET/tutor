using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Redirect;

public class RedirectAgent : StreamingAgent, IRedirectAgent
{
    public RedirectAgent(IAiChatService chatService) : base(chatService) { }

    public IAsyncEnumerable<StreamOutput> StreamAsync(ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = RedirectPromptBuilder.BuildSystemPrompt(task);
        var userMessage = RedirectPromptBuilder.BuildUserMessage();
        return StreamAsync(systemPrompt, userMessage, maxTokens: 128, temperature: 0.7, ct);
    }
}
