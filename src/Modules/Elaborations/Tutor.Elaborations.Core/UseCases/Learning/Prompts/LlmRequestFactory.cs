using System.Text;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class LlmRequestFactory
{
    public static CompletionRequest ForProbing(ConceptRecord record, IReadOnlyList<ConversationTurn> turns,
        ActiveProbe probe)
    {
        return CompletionRequest.Create(ToMessages(turns, RenderProbe(probe)), ProbePrompt.Build(record), maxTokens: 256, temperature: 0.7);
    }

    public static CompletionRequest ForScaffolding(ConceptRecord record, IReadOnlyList<ConversationTurn> turns,
        ActiveProbe probe)
    {
        return CompletionRequest.Create(ToMessages(turns, RenderProbe(probe)), ScaffoldingPrompt.Build(record), maxTokens: 1024, temperature: 0.7);
    }

    public static CompletionRequest ForClarification(ConceptRecord record, IReadOnlyList<ConversationTurn> turns,
        ActiveProbe? lastProbe)
    {
        return CompletionRequest.Create(ToMessages(turns, lastProbe != null ? RenderProbe(lastProbe) : null), ClarificationPrompt.Build(record), maxTokens: 256, temperature: 0.5);
    }

    public static CompletionRequest ForCritique(ConceptRecord record, IReadOnlyList<ConversationTurn> turns,
        TurnEvaluation evaluation)
    {
        return CompletionRequest.Create(ToMessages(turns, RenderEvaluation(evaluation)), CritiquePrompt.Build(record), maxTokens: 512, temperature: 0.7);
    }

    public static CompletionRequest ForSummary(ConceptRecord record, IReadOnlyList<ConversationTurn> turns)
    {
        return CompletionRequest.Create(ToMessages(turns), SummaryPrompt.Build(record), maxTokens: 512, temperature: 0.5);
    }

    public static CompletionRequest ForIntentClassification(ConceptRecord record, IReadOnlyList<ConversationTurn> turns,
        string message)
    {
        var messages = ToMessages(turns.OrderBy(t => t.Order).TakeLast(6));
        messages.Add(ChatMessage.FromUser($"<current-learner-message>{message}</current-learner-message>"));
        return CompletionRequest.Create(messages, IntentPrompt.Build(record), maxTokens: 64, temperature: 0.0);
    }

    public static CompletionRequest ForTurnScoring(ConceptRecord record, IReadOnlyList<ConversationTurn> turns,
        string message)
    {
        var messages = ToMessages(turns);
        messages.Add(ChatMessage.FromUser($"<current-learner-message>{message}</current-learner-message>"));
        return CompletionRequest.Create(messages, ScorePrompt.Build(record), maxTokens: 1024, temperature: 0.0);
    }

    public static CompletionRequest ForClosingScoring(ConceptRecord record, string message)
    {
        var messages = new List<ChatMessage> { ChatMessage.FromUser($"<current-learner-message>{message}</current-learner-message>") };
        return CompletionRequest.Create(messages, ScorePrompt.Build(record, isClosingEvaluation: true), maxTokens: 1024, temperature: 0.0);
    }

    private static List<ChatMessage> ToMessages(IEnumerable<ConversationTurn> turns, string? appendToLast = null)
    {
        var messages = turns.OrderBy(t => t.Order)
            .Select(t => t.Role == TurnRole.Learner
                ? ChatMessage.FromUser(t.Content)
                : ChatMessage.FromAssistant(t.Content))
            .ToList();

        if (appendToLast == null) return messages;

        if (messages.Count > 0 && messages[^1].Role == ChatRole.User)
            messages[^1] = ChatMessage.FromUser(messages[^1].Content + "\n" + appendToLast);
        else
            messages.Add(ChatMessage.FromUser(appendToLast));

        return messages;
    }

    private static string RenderProbe(ActiveProbe probe)
    {
        return $"<target level=\"{probe.Level}\">{probe.Target}</target>";
    }

    private static string RenderEvaluation(TurnEvaluation e)
    {
        var sb = new StringBuilder();
        sb.Append($"<evaluation hasMultipleConcerns=\"{e.HasMultipleConcerns.ToString().ToLowerInvariant()}\">");

        var vagueKeys = e.Assessments.Where(a => a.Grade == 1).Select(a => a.Key).ToList();
        if (vagueKeys.Count > 0)
            sb.Append($"<vague-items>{string.Join(", ", vagueKeys)}</vague-items>");
        if (e.MisconceptionsTriggeredKeys.Count > 0)
            sb.Append($"<triggered-misconceptions>{string.Join(", ", e.MisconceptionsTriggeredKeys)}</triggered-misconceptions>");

        sb.Append("</evaluation>");
        return sb.ToString();
    }
}
