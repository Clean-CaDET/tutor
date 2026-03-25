using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Prompts;

public static class EvaluationPromptBuilder
{
    public static string BuildSystemPrompt(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are an evaluation agent for a Socratic tutoring system.");
        sb.AppendLine("Your task: evaluate the learner's latest response against the concept rubric below.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {record.Title}");
        sb.AppendLine($"Definition: {record.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions:");
        foreach (var kp in record.KeyPropositions)
            sb.AppendLine($"- [KP-{kp.Id}] {kp.Statement}");
        sb.AppendLine();

        sb.AppendLine("## Boundary Conditions:");
        foreach (var bc in record.BoundaryConditions)
            sb.AppendLine($"- [BC-{bc.Id}] {bc.Statement}");
        sb.AppendLine();

        sb.AppendLine("## Common Misconceptions:");
        foreach (var cm in record.CommonMisconceptions.Take(8))
            sb.AppendLine($"- [CM-{cm.Id}] {cm.Description} → Correction: {cm.Correction}");
        sb.AppendLine();

        sb.AppendLine("## Scoring Rules:");
        sb.AppendLine("- Correctness (1-3): Are stated claims true? Check against KPs and BCs.");
        sb.AppendLine("- Completeness (1-3): Are essential KPs covered?");
        sb.AppendLine("- Precision (1-3): Does explanation exclude what it should? Check BCs.");
        sb.AppendLine("- Conciseness (1-3): Unnecessary material, hedging, redundancy?");
        sb.AppendLine("- Evaluate concepts, not language. Grammar and style must not reduce scores.");
        sb.AppendLine("- Resist sycophancy. Evaluate strictly against rubric.");
        sb.AppendLine();

        sb.AppendLine("## Output Format (JSON only, no other text):");
        sb.AppendLine("""
{
  "correctnessScore": 1-3,
  "completenessScore": 1-3,
  "precisionScore": 1-3,
  "concisenessScore": 1-3,
  "justification": "brief explanation of scores",
  "propositionsCoveredIds": [list of KP IDs covered in this turn],
  "misconceptionsTriggeredIds": [list of CM IDs triggered],
  "novelMisconceptions": "any misconceptions not in the list, or null",
  "isSubstantive": true/false
}
""");

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
