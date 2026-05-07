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
        IReadOnlyList<Probe> probes)
    {
        var messages = new List<ChatMessage> { ChatMessage.FromUser(RenderFeedbackInput(elaboration, probes)) };
        return CompletionRequest.Create(messages, EvaluationFeedbackPrompt.Build(record), maxTokens: 512, temperature: 0.7);
    }

    private static string RenderFeedbackInput(string elaboration, IReadOnlyList<Probe> probes)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<elaboration>{elaboration}</elaboration>");

        var misconceptions = probes.Where(p => p.ScoredTarget.Type == TargetType.Misconception).ToList();
        var gaps = probes.Where(p => p.ScoredTarget.Type != TargetType.Misconception).ToList();

        if (misconceptions.Count > 0)
        {
            sb.Append("<misconceptions>");
            foreach (var p in misconceptions)
                sb.Append($"<misconception key=\"{p.ScoredTarget.Key}\" stagnantCount=\"{p.StagnantCount}\"/>");
            sb.Append("</misconceptions>");
        }

        if (gaps.Count > 0)
        {
            sb.Append("<gaps>");
            foreach (var p in gaps)
                sb.Append($"<gap key=\"{p.ScoredTarget.Key}\" type=\"{p.ScoredTarget.Type.ToString().ToLowerInvariant()}\" grade=\"{p.ScoredTarget.Grade}\" stagnantCount=\"{p.StagnantCount}\"/>");
            sb.Append("</gaps>");
        }

        return sb.ToString();
    }
}
