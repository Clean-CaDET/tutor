using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Scorer;

public static class ScorerPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task)
    {
        var hasBoundaryConditions = task.BoundaryConditions.Count != 0;
        var hasCommonMisconceptions = task.CommonMisconceptions.Count != 0;
        var hasKeyRelations = task.KeyRelations.Count != 0;

        var sb = new StringBuilder();
        sb.AppendLine("You are a scoring agent for a Socratic tutoring system.");
        sb.AppendLine("The learner's latest message is known to be Substantive (an attempt at explanation). Score it against the concept rubric and tag which propositions/relations/misconceptions it hits. Output JSON only, no other text.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions:");
        foreach (var kp in task.KeyPropositions)
            sb.AppendLine($"ID={kp.Id} {kp.Statement}");
        sb.AppendLine();

        if (hasBoundaryConditions)
        {
            sb.AppendLine("## Boundary Conditions:");
            foreach (var bc in task.BoundaryConditions)
                sb.AppendLine($"ID={bc.Id} {bc.Statement}");
            sb.AppendLine();
        }

        if (hasCommonMisconceptions)
        {
            sb.AppendLine("## Common Misconceptions:");
            foreach (var cm in task.CommonMisconceptions.Take(8))
                sb.AppendLine($"ID={cm.Id} {cm.Description} → Correction: {cm.Correction}");
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
                sb.AppendLine($"ID={kr.Id} {sourceText} → {targetText}. Mechanism: {kr.Mechanism}");
            }
            sb.AppendLine();
        }

        sb.AppendLine("## Scope rule");
        sb.AppendLine("Score only the message demarcated as '## Message to score'. Do not credit the learner for content that appears in [TUTOR] lines or that the learner has only repeated from a preceding [TUTOR] line.");
        sb.AppendLine();

        sb.AppendLine("## Rubric:");
        sb.AppendLine(hasBoundaryConditions
            ? "- Correctness (1-3): Are stated claims true? Check against KPs and BCs."
            : "- Correctness (1-3): Are stated claims true? Check against KPs.");
        sb.AppendLine("- Completeness (1-3): Are essential KPs covered in THIS message?");
        if (hasBoundaryConditions)
            sb.AppendLine("- Discrimination (1-3): Does the explanation correctly exclude non-examples? Check BCs.");
        if (hasKeyRelations)
            sb.AppendLine("- Integration (1-3): Did the learner articulate key relations *with mechanism*? 1=no relation, 2=relation without mechanism, 3=relation with mechanism matching the authored description.");
        sb.AppendLine("- Evaluate concepts, not language. Grammar and style must not reduce scores.");
        sb.AppendLine("- Resist sycophancy. Evaluate strictly against rubric.");
        sb.AppendLine();

        sb.AppendLine("## Concern count (used by the orchestrator to route to critique vs probe):");
        sb.AppendLine("Count distinct concerns in the message. A concern is any of:");
        sb.AppendLine("  - a stated inaccuracy (a claim that contradicts a KP or BC);");
        sb.AppendLine(hasCommonMisconceptions
            ? "  - a triggered known misconception or a novel misconception;"
            : "  - a novel misconception (none are pre-catalogued for this concept);");
        sb.AppendLine("  - a vague or hand-wavy claim that references a KP without articulating it.");
        sb.AppendLine("Set hasMultipleConcerns=true if the count is two or more; false otherwise.");
        sb.AppendLine();

        sb.AppendLine("## Output Format (JSON only, no other text):");
        var fields = new List<string>
        {
            "\"correctnessScore\": 1-3",
            "\"completenessScore\": 1-3"
        };
        if (hasBoundaryConditions) fields.Add("\"discriminationScore\": 1-3");
        if (hasKeyRelations) fields.Add("\"integrationScore\": 1-3");
        fields.Add("\"justification\": \"brief explanation of scores\"");
        fields.Add("\"propositionsCoveredIds\": [number list of KP IDs covered in this turn]");
        if (hasCommonMisconceptions) fields.Add("\"misconceptionsTriggeredIds\": [number list of CM IDs triggered]");
        if (hasKeyRelations) fields.Add("\"relationsArticulatedIds\": [number list of KR IDs articulated with mechanism this turn]");
        if (hasCommonMisconceptions) fields.Add("\"novelMisconceptions\": \"any misconceptions not in the list, or null\"");
        fields.Add("\"hasMultipleConcerns\": true|false");

        sb.AppendLine("{");
        sb.AppendLine(string.Join(",\n", fields.Select(f => "  " + f)));
        sb.AppendLine("}");
        return sb.ToString();
    }

    public static string BuildUserMessage(string learnerContent, List<ConversationTurn> history)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Conversation so far (for context only — DO NOT score this)");
        if (history.Count == 0)
        {
            sb.AppendLine("(no prior turns)");
        }
        else
        {
            foreach (var turn in history)
            {
                var label = turn.Role == TurnRole.Learner ? "LEARNER" : "TUTOR";
                sb.AppendLine($"[{label}]: {turn.Content}");
            }
        }
        sb.AppendLine();
        sb.AppendLine("## Message to score (this is the ONLY message you are scoring)");
        sb.AppendLine($"[LEARNER]: {learnerContent}");
        sb.AppendLine();
        sb.AppendLine("Score only the final [LEARNER] message under '## Message to score'.");
        return sb.ToString();
    }
}
