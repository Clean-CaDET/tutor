using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Prompts;

public static class EvaluationPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task)
    {
        var hasBoundaryConditions = task.BoundaryConditions.Any();
        var hasCommonMisconceptions = task.CommonMisconceptions.Any();
        var hasKeyRelations = task.KeyRelations.Any();

        var sb = new StringBuilder();
        sb.AppendLine("You are an evaluation agent for a Socratic tutoring system.");
        sb.AppendLine("Your task: evaluate the learner's latest response against the concept rubric below.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions:");
        foreach (var kp in task.KeyPropositions)
            sb.AppendLine($"- [KP-{kp.Id}] {kp.Statement}");
        sb.AppendLine();

        if (hasBoundaryConditions)
        {
            sb.AppendLine("## Boundary Conditions:");
            foreach (var bc in task.BoundaryConditions)
                sb.AppendLine($"- [BC-{bc.Id}] {bc.Statement}");
            sb.AppendLine();
        }

        if (hasCommonMisconceptions)
        {
            sb.AppendLine("## Common Misconceptions:");
            foreach (var cm in task.CommonMisconceptions.Take(8))
                sb.AppendLine($"- [CM-{cm.Id}] {cm.Description} → Correction: {cm.Correction}");
            sb.AppendLine();
        }

        if (hasKeyRelations)
        {
            sb.AppendLine("## Key Relations:");
            var kpById = task.KeyPropositions.ToDictionary(kp => kp.Id, kp => kp.Statement);
            foreach (var kr in task.KeyRelations)
            {
                var sourceText = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, $"KP-{kr.SourceKeyPropositionId}");
                var targetText = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, $"KP-{kr.TargetKeyPropositionId}");
                sb.AppendLine($"- [KR-{kr.Id}] {sourceText} → {targetText}. Mechanism: {kr.Mechanism}");
            }
            sb.AppendLine();
        }

        sb.AppendLine("## Scoring Rules:");
        var correctnessLine = hasBoundaryConditions
            ? "- Correctness (1-3): Are stated claims true? Check against KPs and BCs."
            : "- Correctness (1-3): Are stated claims true? Check against KPs.";
        sb.AppendLine(correctnessLine);
        sb.AppendLine("- Completeness (1-3): Are essential KPs covered?");
        if (hasBoundaryConditions)
            sb.AppendLine("- Discrimination (1-3): Does the explanation correctly exclude non-examples? Check BCs.");
        if (hasKeyRelations)
            sb.AppendLine("- Integration (1-3): Did the learner articulate the key relations *with mechanism*? Score 1 if no relation articulated, 2 if relations mentioned without mechanism, 3 if relations articulated with explicit mechanism matching the authored description.");
        sb.AppendLine("- Evaluate concepts, not language. Grammar and style must not reduce scores.");
        sb.AppendLine("- Resist sycophancy. Evaluate strictly against rubric.");
        sb.AppendLine();

        sb.AppendLine("## Output Format (JSON only, no other text):");
        sb.AppendLine("{");
        sb.AppendLine("  \"correctnessScore\": 1-3,");
        sb.AppendLine("  \"completenessScore\": 1-3,");
        if (hasBoundaryConditions)
            sb.AppendLine("  \"discriminationScore\": 1-3,");
        if (hasKeyRelations)
            sb.AppendLine("  \"integrationScore\": 1-3,");
        sb.AppendLine("  \"justification\": \"brief explanation of scores\",");
        sb.AppendLine("  \"propositionsCoveredIds\": [list of KP IDs covered in this turn],");
        if (hasCommonMisconceptions)
            sb.AppendLine("  \"misconceptionsTriggeredIds\": [list of CM IDs triggered],");
        if (hasKeyRelations)
            sb.AppendLine("  \"relationsArticulatedIds\": [list of KR IDs articulated with mechanism this turn],");
        if (hasCommonMisconceptions)
            sb.AppendLine("  \"novelMisconceptions\": \"any misconceptions not in the list, or null\",");
        sb.AppendLine("  \"isSubstantive\": true/false");
        sb.AppendLine("}");

        return sb.ToString();
    }

    public static List<(string role, string content)> BuildMessages(
        string learnerContent, List<ConversationTurn> history)
    {
        var messages = new List<(string role, string content)>();
        foreach (var turn in history)
        {
            var role = turn.Role == TurnRole.Learner ? "user" : "assistant";
            messages.Add((role, turn.Content));
        }
        messages.Add(("user", learnerContent));
        return messages;
    }
}
