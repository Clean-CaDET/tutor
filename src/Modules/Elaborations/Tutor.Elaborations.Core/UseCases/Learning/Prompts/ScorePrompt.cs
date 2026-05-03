using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class ScorePrompt
{
    public static string Build(ConceptRecord record, bool isClosingEvaluation = false)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a scoring agent for a Socratic tutoring system. Output JSON only, no other text.");
        sb.AppendLine();

        sb.AppendLine("# Scope rule");
        if (isClosingEvaluation)
            sb.AppendLine("Score only the text inside <current-learner-message>…</current-learner-message>. This is the learner's final consolidated answer submitted in isolation. Evaluate it as a standalone response.");
        else
            sb.AppendLine("Score only the text inside <current-learner-message>…</current-learner-message> in the final user message. Do not credit the learner for content that appears in prior assistant turns or that the learner has only repeated from a preceding assistant turn.");
        sb.AppendLine();

        sb.AppendLine("# Rating task");
        sb.AppendLine("Rate EVERY Key Proposition and Key Relation from the concept rubric above. All must appear in the output, even if not addressed.");
        sb.AppendLine("Use this scale:");
        sb.AppendLine("  0 — not addressed in this message");
        sb.AppendLine("  1 — vague or incomplete: concept touched but not clearly articulated");
        sb.AppendLine("  2 — partially correct: core idea present but missing detail or precision");
        sb.AppendLine("  3 — well-articulated: accurate and sufficiently complete");
        sb.AppendLine("For each item, set type to \"proposition\" for Key Propositions and \"relation\" for Key Relations.");
        sb.AppendLine("Evaluate concepts, not language. Grammar and style must not reduce scores.");
        sb.AppendLine("Resist sycophancy. Evaluate strictly against the rubric.");
        sb.AppendLine();

        if (record.CommonMisconceptions.Count != 0)
        {
            sb.AppendLine("# Misconception detection");
            sb.AppendLine("List the keys of any known misconceptions triggered in this message.");
            sb.AppendLine();
        }

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows prior turns (user=learner, assistant=tutor) for context only — DO NOT score these.");
        sb.AppendLine("The final user message contains the message to score inside <current-learner-message>…</current-learner-message>.");
        sb.AppendLine();

        var assessmentExample = record.KeyPropositions.Count > 0
            ? $"{{ \"key\": \"{record.KeyPropositions[0].Key}\", \"type\": \"proposition\", \"grade\": 0 }}"
            : "{ \"key\": \"P1\", \"type\": \"proposition\", \"grade\": 0 }";
        sb.AppendLine("# Output Format (JSON only, no other text)");
        sb.AppendLine("{");
        sb.AppendLine($"  \"assessments\": [ {assessmentExample}, … one entry per KP and KR ],");
        if (record.CommonMisconceptions.Count != 0)
            sb.AppendLine("  \"misconceptionsTriggeredKeys\": [string list of CM keys triggered, e.g. [\"M1\"]]");
        else
            sb.AppendLine("  \"misconceptionsTriggeredKeys\": []");
        sb.AppendLine("}");

        return sb.ToString();
    }
}
