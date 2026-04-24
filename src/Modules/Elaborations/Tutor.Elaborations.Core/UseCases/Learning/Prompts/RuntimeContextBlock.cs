using System.Text;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

/// <summary>
/// Renders an <see cref="AgentTurnContext"/> as a single trailing user message.
/// The XML-ish tags match the schema described in each agent's system prompt
/// so the model knows exactly how to interpret the runtime state.
/// </summary>
public static class RuntimeContextBlock
{
    public static string Render(AgentTurnContext ctx)
    {
        var sb = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(ctx.ProgressLine))
            sb.AppendLine($"<progress>{ctx.ProgressLine}</progress>");

        if (ctx.Target is { } t)
            sb.AppendLine($"<target>{t}</target>");

        if (ctx.SoftCapReached)
            sb.AppendLine("<soft-cap/>");

        if (ctx.Evaluation is { } e)
            sb.AppendLine(RenderEvaluation(e));

        if (!string.IsNullOrWhiteSpace(ctx.CurrentLearnerMessage))
            sb.AppendLine($"<current-learner-message>{ctx.CurrentLearnerMessage}</current-learner-message>");

        sb.Append($"<instruction>{ctx.Instruction}</instruction>");
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
        if (e.DiscriminationScore.HasValue) attrs.Add($"discrimination=\"{e.DiscriminationScore.Value}\"");
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
