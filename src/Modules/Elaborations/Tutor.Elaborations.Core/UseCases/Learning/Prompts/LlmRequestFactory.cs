using System.Text;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class LlmRequestFactory
{
    private static readonly string ScoreTemplate = LoadTemplate("ScorePrompt.md");
    private static readonly string EvaluationFeedbackTemplate = LoadTemplate("EvaluationFeedbackPrompt.md");

    public static CompletionRequest ForElaborationScoring(ConceptRecord record, string elaboration)
    {
        var messages = new List<ChatMessage> { ChatMessage.FromUser($"<elaboration>{elaboration}</elaboration>") };
        return CompletionRequest.Create(messages, ScoreTemplate + "\n" + ConceptRubricSection.Render(record), maxTokens: 8192);
    }

    public static CompletionRequest ForEvaluationFeedback(ConceptRecord record, string elaboration,
        IReadOnlyList<Probe> probes)
    {
        var messages = new List<ChatMessage> { ChatMessage.FromUser(RenderFeedbackInput(record, elaboration, probes)) };
        return CompletionRequest.Create(messages, EvaluationFeedbackTemplate, maxTokens: 8192);
    }

    private static string RenderFeedbackInput(ConceptRecord record, string elaboration, IReadOnlyList<Probe> probes)
    {
        var statementByKey = record.KeyPropositions.ToDictionary(kp => kp.Key, kp => kp.Statement);
        var correctionByKey = record.KeyPropositions
            .Where(kp => kp.Misconception != null)
            .ToDictionary(kp => kp.Key, kp => kp.Misconception!.Correction);
        var hintByKey = record.KeyPropositions
            .Where(kp => kp.Hint != null)
            .ToDictionary(kp => kp.Key, kp => kp.Hint!);

        var sb = new StringBuilder();
        sb.AppendLine($"<elaboration>{elaboration}</elaboration>");
        sb.Append("<gaps>");
        foreach (var p in probes)
        {
            var target = p.ScoredTarget;
            var correctionAttr = target.Grade == -2
                ? $" correction=\"{correctionByKey.GetValueOrDefault(target.Key, "")}\""
                : "";
            var hintAttr = (target.Grade == 0 || target.Grade == 1) && hintByKey.TryGetValue(target.Key, out var hint)
                ? $" hint=\"{hint}\""
                : "";
            sb.Append($"<gap key=\"{target.Key}\" grade=\"{target.Grade}\" statement=\"{statementByKey.GetValueOrDefault(target.Key, "")}\" stagnantCount=\"{p.StagnantCount}\" evidence=\"{target.Evidence}\"{correctionAttr}{hintAttr}/>");
        }
        sb.Append("</gaps>");

        return sb.ToString();
    }

    private static string LoadTemplate(string fileName)
    {
        var assembly = typeof(LlmRequestFactory).Assembly;
        using var stream = assembly.GetManifestResourceStream(
            $"Tutor.Elaborations.Core.UseCases.Learning.Prompts.{fileName}")!;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
