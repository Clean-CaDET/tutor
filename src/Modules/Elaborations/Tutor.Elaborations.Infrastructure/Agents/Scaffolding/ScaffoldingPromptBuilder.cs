using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Infrastructure.Agents.Scaffolding;

public static class ScaffoldingPromptBuilder
{
    public static string BuildSystemPrompt(
        ConceptElaborationTask task, ProbeDirective target)
    {
        var targetText = ResolveTargetStatement(task, target);

        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring scaffolding agent. Speak Serbian.");
        sb.AppendLine("The learner has stalled after repeated probes on one target. Provide a concrete structural scaffold that gives them a foothold WITHOUT stating the target.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();
        sb.AppendLine("## Target (INTERNAL — NEVER reveal or paraphrase this text; it must come from the learner):");
        sb.AppendLine($"[{target.TargetType}-{target.TargetId}] {targetText}");
        sb.AppendLine();
        sb.AppendLine("## Scaffolding options (pick ONE that fits best):");
        sb.AppendLine("1. **Forced choice** — offer two options, exactly one of which points toward the target, both phrased at the same level of abstraction. Ask the learner to choose and justify.");
        sb.AppendLine("2. **Code skeleton with labeled blanks** — a minimal pseudo-code / test skeleton with `// ___` blanks labeled by role (e.g. `// pripremi očekivano`). Ask the learner to fill one blank.");
        sb.AppendLine("3. **Analogy** — map the target to a simpler, non-technical domain. Present the analogy's structure and ask the learner to translate it back to the concept.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Keep it short. A code skeleton with 3-4 labeled lines, or a two-option forced choice, or a 2-sentence analogy.");
        sb.AppendLine("- NEVER state the target text or a paraphrase close enough to give it away. The scaffold must make the learner do the articulation.");
        sb.AppendLine("- End with one concrete, narrow request (\"Koja opcija i zašto?\" / \"Šta ide na mestu ___?\" / \"Prevedi ovu analogiju na naš koncept.\").");
        sb.AppendLine("- No bullet lists beyond what the scaffold structurally requires.");
        return sb.ToString();
    }

    public static string BuildUserMessage(ConversationAttempt attempt)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Conversation so far (so you can see the learner's prior attempts on this target)");
        foreach (var turn in attempt.Turns)
        {
            var label = turn.Role == TurnRole.Learner ? "LEARNER" : "TUTOR";
            sb.AppendLine($"[{label}]: {turn.Content}");
        }
        sb.AppendLine();
        sb.AppendLine("Produce the TUTOR's scaffold per the system prompt.");
        return sb.ToString();
    }

    private static string ResolveTargetStatement(ConceptElaborationTask task, ProbeDirective directive)
    {
        if (directive.TargetType == ProbeTargetType.KeyProposition)
        {
            var kp = task.KeyPropositions.FirstOrDefault(p => p.Id == directive.TargetId);
            return kp?.Statement ?? "(unknown)";
        }
        var kr = task.KeyRelations.FirstOrDefault(r => r.Id == directive.TargetId);
        if (kr == null) return "(unknown)";
        var kpById = task.KeyPropositions.ToDictionary(p => p.Id, p => p.Statement);
        var source = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, "?");
        var target = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, "?");
        return $"{source} → {target}. Mechanism: {kr.Mechanism}";
    }
}
