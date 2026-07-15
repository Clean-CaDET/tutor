using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

/// <summary>
/// Renders the concept rubric (KPs with their scoped misconceptions) as a markdown block.
/// Output is byte-stable for a given <see cref="ConceptRecord"/> so the whole block
/// can live at the top of every agent's system prompt and serve as a shared provider-side cache prefix.
/// No per-turn state (coverage markers, soft-cap flags, progress) is rendered here.
/// </summary>
public static class ConceptRubricSection
{
    public static string Render(ConceptRecord record)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# Concept");
        sb.AppendLine();
        sb.AppendLine("## Key Propositions");
        foreach (var kp in record.KeyPropositions)
        {
            sb.AppendLine($"- [{kp.Key}] {kp.Statement}");
            if (kp.Misconception != null)
                sb.AppendLine($"  - Misconception: {kp.Misconception.Description} — Correction: {kp.Misconception.Correction}");
        }

        return sb.ToString().TrimEnd() + "\n";
    }
}
