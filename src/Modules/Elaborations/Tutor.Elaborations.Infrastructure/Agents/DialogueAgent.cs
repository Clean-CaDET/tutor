using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
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

    public async IAsyncEnumerable<string> StreamAsync(TurnEvaluation evaluation,
        List<ConversationTurn> history, ConceptRecord conceptRecord,
        ConversationState state, [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = DialoguePromptBuilder.BuildSystemPrompt(conceptRecord, state);
        var messageData = DialoguePromptBuilder.BuildMessages(history);

        var evalSummary = $"[Evaluation: correctness={evaluation.CorrectnessScore}, " +
            $"completeness={evaluation.CompletenessScore}, " +
            $"precision={evaluation.PrecisionScore}, " +
            $"conciseness={evaluation.ConcisenessScore}. " +
            $"Justification: {evaluation.Justification}]";
        messageData.Add(("user", evalSummary));

        var messages = messageData.Select(m =>
            m.role == "user" ? ChatMessage.FromUser(m.content) : ChatMessage.FromAssistant(m.content));

        var request = CompletionRequest.Create(messages, systemPrompt, maxTokens: 512, temperature: 0.7);

        await foreach (var token in _chatService.StreamAsync(request, ct))
        {
            yield return token;
        }
    }
}
