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

        var misconceptions = targets.Where(t => t.ScoredTarget.Type == TargetType.Misconception).ToList();
        var gaps = targets.Where(t => t.ScoredTarget.Type != TargetType.Misconception).ToList();

        if (misconceptions.Count > 0)
        {
            sb.Append("<misconceptions>");
            foreach (var t in misconceptions)
                sb.Append($"<misconception key=\"{t.ScoredTarget.Key}\" probeCount=\"{t.ProbesWithoutGradeChangeCount}\"/>");
            sb.Append("</misconceptions>");
        }

        if (gaps.Count > 0)
        {
            sb.Append("<gaps>");
            foreach (var t in gaps)
                sb.Append($"<gap key=\"{t.ScoredTarget.Key}\" type=\"{t.ScoredTarget.Type.ToString().ToLowerInvariant()}\" grade=\"{t.ScoredTarget.Grade}\" probeCount=\"{t.ProbesWithoutGradeChangeCount}\"/>");
            sb.Append("</gaps>");
        }

        return sb.ToString();
    }
}
