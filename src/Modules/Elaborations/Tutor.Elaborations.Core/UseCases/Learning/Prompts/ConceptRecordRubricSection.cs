using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

/// <summary>
/// Renders the concept rubric (definition, KPs, BCs, CMs, KRs) as a markdown block.
/// Output is byte-stable for a given <see cref="ConceptRecord"/> so the whole block
/// can live at the top of every agent's system prompt and serve as a shared provider-side cache prefix.
/// No per-turn state (coverage markers, soft-cap flags, progress) is rendered here.
/// </summary>
public static class ConceptRecordRubricSection
{
    public static string Render(ConceptRecord record)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# Concept");
        sb.AppendLine();
        sb.AppendLine("## Canonical Definition");
        sb.AppendLine(record.CanonicalDefinition);
        sb.AppendLine();

        sb.AppendLine("## Key Propositions");
        foreach (var kp in record.KeyPropositions)
            sb.AppendLine($"- [{kp.Key}] {kp.Statement}");
        sb.AppendLine();

        if (record.BoundaryConditions.Count > 0)
        {
            sb.AppendLine("## Boundary Conditions");
            foreach (var bc in record.BoundaryConditions)
                sb.AppendLine($"- [{bc.Key}] {bc.Statement}");
            sb.AppendLine();
        }

        if (record.CommonMisconceptions.Count > 0)
        {
            sb.AppendLine("## Common Misconceptions");
            foreach (var cm in record.CommonMisconceptions)
                sb.AppendLine($"- [{cm.Key}] {cm.Description} — correction: {cm.Correction}");
            sb.AppendLine();
        }

        if (record.KeyRelations.Count > 0)
        {
            sb.AppendLine("## Key Relations");
            var kpByKey = record.KeyPropositions.ToDictionary(kp => kp.Key, kp => kp.Statement);
            foreach (var kr in record.KeyRelations)
            {
                var source = kpByKey.GetValueOrDefault(kr.SourceKey, kr.SourceKey);
                var target = kpByKey.GetValueOrDefault(kr.TargetKey, kr.TargetKey);
                sb.AppendLine($"- [{kr.Key}] {source} → {target}. Mechanism: {kr.Mechanism}");
            }
        }

        return sb.ToString().TrimEnd() + "\n";
    }
}
