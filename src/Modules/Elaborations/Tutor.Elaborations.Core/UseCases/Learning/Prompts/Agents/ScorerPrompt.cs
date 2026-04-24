using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public static class ScorerPrompt
{
    public static string Build(ConceptRecord record)
    {
        var hasBoundaryConditions = record.BoundaryConditions.Count != 0;
        var hasCommonMisconceptions = record.CommonMisconceptions.Count != 0;
        var hasKeyRelations = record.KeyRelations.Count != 0;

        var sb = new StringBuilder();
        sb.AppendLine(ConceptRecordRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a scoring agent for a Socratic tutoring system.");
        sb.AppendLine("The learner's latest message is known to be Substantive (an attempt at explanation). Score it against the concept rubric and tag which propositions/relations/misconceptions it hits. Output JSON only, no other text.");
        sb.AppendLine();

        sb.AppendLine("# Scope rule");
        sb.AppendLine("Score only the text inside <current-learner-message>…</current-learner-message> in the final user message. Do not credit the learner for content that appears in prior assistant turns or that the learner has only repeated from a preceding assistant turn.");
        sb.AppendLine();

        sb.AppendLine("# Rubric");
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

        sb.AppendLine("# Concern count (used by the orchestrator to route to critique vs probe)");
        sb.AppendLine("Count distinct concerns in the message. A concern is any of:");
        sb.AppendLine("  - a stated inaccuracy (a claim that contradicts a KP or BC);");
        sb.AppendLine(hasCommonMisconceptions
            ? "  - a triggered known misconception or a novel misconception;"
            : "  - a novel misconception (none are pre-catalogued for this concept);");
        sb.AppendLine("  - a vague or hand-wavy claim that references a KP without articulating it.");
        sb.AppendLine("Set hasMultipleConcerns=true if the count is two or more; false otherwise.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows prior turns (user=learner, assistant=tutor) for context only — DO NOT score these.");
        sb.AppendLine("The final user message contains the message to score inside <current-learner-message>…</current-learner-message>, followed by <instruction>…</instruction>.");
        sb.AppendLine();

        sb.AppendLine("# Output Format (JSON only, no other text)");
        var fields = new List<string>
        {
            "\"correctnessScore\": 1-3",
            "\"completenessScore\": 1-3"
        };
        if (hasBoundaryConditions) fields.Add("\"discriminationScore\": 1-3");
        if (hasKeyRelations) fields.Add("\"integrationScore\": 1-3");
        fields.Add("\"justification\": \"brief explanation of scores\"");
        fields.Add("\"propositionsCoveredKeys\": [string list of KP keys covered in this turn, e.g. [\"P1\", \"P2\"]]");
        if (hasCommonMisconceptions) fields.Add("\"misconceptionsTriggeredKeys\": [string list of CM keys triggered, e.g. [\"M1\"]]");
        if (hasKeyRelations) fields.Add("\"relationsArticulatedKeys\": [string list of KR keys articulated with mechanism this turn, e.g. [\"R1\"]]");
        if (hasCommonMisconceptions) fields.Add("\"novelMisconceptions\": \"any misconceptions not in the list, or null\"");
        fields.Add("\"hasMultipleConcerns\": true|false");

        sb.AppendLine("{");
        sb.AppendLine(string.Join(",\n", fields.Select(f => "  " + f)));
        sb.AppendLine("}");
        return sb.ToString();
    }
}
