using System.Text;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class RuntimeContextBlock
{
    public static string Render(AgentTurnContext ctx)
    {
        var sb = new StringBuilder();

        if (ctx.Target is { } t)
        {
            if (ctx.Level is { } lvl)
                sb.AppendLine($"<target level=\"{lvl}\">{t}</target>");
            else
                sb.AppendLine($"<target>{t}</target>");
        }

        if (ctx.Evaluation is { } e)
            sb.AppendLine(RenderEvaluation(e));

        if (!string.IsNullOrWhiteSpace(ctx.CurrentLearnerMessage))
            sb.Append($"<current-learner-message>{ctx.CurrentLearnerMessage}</current-learner-message>");

        return sb.ToString();
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
