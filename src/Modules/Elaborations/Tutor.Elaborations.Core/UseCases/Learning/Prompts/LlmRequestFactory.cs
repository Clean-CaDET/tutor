using System.Text;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class LlmRequestFactory
{
    public static CompletionRequest ForProbing(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, ActiveProbe probe)
    {
        var messages = ToMessages(turns);
        messages.Add(ChatMessage.FromUser(RenderProbe(probe)));
        return CompletionRequest.Create(messages, ProbePrompt.Build(record), maxTokens: 256, temperature: 0.7);
    }

    public static CompletionRequest ForScaffolding(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, ActiveProbe probe)
    {
        var messages = ToMessages(turns);
        messages.Add(ChatMessage.FromUser(RenderProbe(probe)));
        return CompletionRequest.Create(messages, ScaffoldingPrompt.Build(record), maxTokens: 512, temperature: 0.7);
    }

    public static CompletionRequest ForClarification(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, ActiveProbe? lastProbe)
    {
        var messages = ToMessages(turns);
        if (lastProbe != null)
            messages.Add(ChatMessage.FromUser(RenderProbe(lastProbe)));
        return CompletionRequest.Create(messages, ClarificationPrompt.Build(record), maxTokens: 256, temperature: 0.5);
    }

    public static CompletionRequest ForCritique(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, TurnEvaluation evaluation)
    {
        var messages = ToMessages(turns);
        messages.Add(ChatMessage.FromUser(RenderEvaluation(evaluation)));
        return CompletionRequest.Create(messages, CritiquePrompt.Build(record), maxTokens: 512, temperature: 0.7);
    }

    public static CompletionRequest ForSummary(IReadOnlyList<ConversationTurn> turns, ConceptRecord record)
    {
        return CompletionRequest.Create(ToMessages(turns), SummaryPrompt.Build(record), maxTokens: 256, temperature: 0.5);
    }

    public static CompletionRequest ForIntentClassification(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, string message)
    {
        var messages = ToMessages(turns, 6);
        messages.Add(ChatMessage.FromUser($"<current-learner-message>{message}</current-learner-message>"));
        return CompletionRequest.Create(messages, IntentPrompt.Build(record), maxTokens: 64, temperature: 0.0);
    }

    public static CompletionRequest ForTurnScoring(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, string message)
    {
        var messages = ToMessages(turns);
        messages.Add(ChatMessage.FromUser($"<current-learner-message>{message}</current-learner-message>"));
        return CompletionRequest.Create(messages, ScoreTurnPrompt.Build(record), maxTokens: 1024, temperature: 0.0);
    }

    public static CompletionRequest ForClosingScoring(IReadOnlyList<ConversationTurn> turns, ConceptRecord record, string message)
    {
        var messages = ToMessages(turns);
        messages.Add(ChatMessage.FromUser($"<current-learner-message>{message}</current-learner-message>"));
        return CompletionRequest.Create(messages, ScoreClosingPrompt.Build(record), maxTokens: 1024, temperature: 0.0);
    }

    private static List<ChatMessage> ToMessages(IEnumerable<ConversationTurn> turns, int? lastN = null)
    {
        var ordered = turns.OrderBy(t => t.Order);
        var window = lastN is { } n ? ordered.TakeLast(n) : ordered;
        return window.Select(t => t.Role == TurnRole.Learner
            ? ChatMessage.FromUser(t.Content)
            : ChatMessage.FromAssistant(t.Content)).ToList();
    }

    private static string RenderProbe(ActiveProbe probe)
    {
        return $"<target level=\"{probe.Level}\">{probe.Target}</target>";
    }

    private static string RenderEvaluation(TurnEvaluation e)
    {
        var sb = new StringBuilder();
        var attrs = new List<string>
        {
            $"correctness=\"{e.CorrectnessScore}\"",
            $"completeness=\"{e.CompletenessScore}\""
        };
        if (e.IntegrationScore.HasValue) attrs.Add($"integration=\"{e.IntegrationScore.Value}\"");
        attrs.Add($"hasMultipleConcerns=\"{e.HasMultipleConcerns.ToString().ToLowerInvariant()}\"");

        sb.Append($"<evaluation {string.Join(' ', attrs)}>");
        sb.Append($"<justification>{e.Justification}</justification>");
        if (e.MisconceptionsTriggeredKeys.Count > 0)
            sb.Append($"<triggered-misconceptions>{string.Join(", ", e.MisconceptionsTriggeredKeys)}</triggered-misconceptions>");
        if (!string.IsNullOrWhiteSpace(e.NovelMisconceptions))
            sb.Append($"<novel-misconceptions>{e.NovelMisconceptions}</novel-misconceptions>");
        sb.Append("</evaluation>");
        return sb.ToString();
    }
}
