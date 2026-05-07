using System.Text;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class LlmRequestFactory
{
    public static CompletionRequest ForElaborationScoring(ConceptRecord record, string elaboration)
    {
        var messages = new List<ChatMessage> { ChatMessage.FromUser($"<elaboration>{elaboration}</elaboration>") };
        return CompletionRequest.Create(messages, ScorePrompt.Build(record), maxTokens: 1024, temperature: 0.0);
    }

    public static CompletionRequest ForEvaluationFeedback(ConceptRecord record, string elaboration,
        IReadOnlyList<FeedbackTarget> targets)
    {
        var messages = new List<ChatMessage> { ChatMessage.FromUser(RenderFeedbackInput(elaboration, targets)) };
        return CompletionRequest.Create(messages, EvaluationFeedbackPrompt.Build(record), maxTokens: 512, temperature: 0.7);
    }

    private static string RenderFeedbackInput(string elaboration, IReadOnlyList<FeedbackTarget> targets)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<elaboration>{elaboration}</elaboration>");
        sb.Append("<gaps>");
        foreach (var t in targets)
        {
            var support = t.NeedsSupport.ToString().ToLowerInvariant();
            if (t.Type == TargetType.Misconception)
                sb.Append($"<misconception key=\"{t.Key}\" needsSupport=\"{support}\"/>");
            else
                sb.Append($"<gap key=\"{t.Key}\" type=\"{t.Type.ToString()!.ToLowerInvariant()}\" grade=\"{t.Grade}\" needsSupport=\"{support}\"/>");
        }
        sb.Append("</gaps>");
        return sb.ToString();
    }
}
