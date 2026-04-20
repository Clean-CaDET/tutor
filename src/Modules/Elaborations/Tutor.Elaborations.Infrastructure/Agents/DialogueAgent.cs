using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Infrastructure.Agents.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class DialogueAgent : IDialogueAgent
{
    private readonly IAiChatService _chatService;

    public DialogueAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(TurnAnalysis analysis,
        ConversationAttempt attempt, ConceptElaborationTask task,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = DialoguePromptBuilder.BuildSystemPrompt(task, attempt, analysis);
        var userMessage = DialoguePromptBuilder.BuildUserMessage(attempt.Turns.ToList(), analysis);

        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 512, temperature: 0.7);

        await foreach (var token in _chatService.StreamAsync(request, ct))
        {
            yield return token;
        }
    }
}
