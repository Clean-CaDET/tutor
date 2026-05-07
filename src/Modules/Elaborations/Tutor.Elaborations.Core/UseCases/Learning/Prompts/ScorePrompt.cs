using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class ScorePrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a scoring agent. Output JSON only, no other text.");
        sb.AppendLine();

        sb.AppendLine("# Scoring task");
        sb.AppendLine("Score the learner's Elaboration inside <elaboration>…</elaboration> against every Key Proposition and Key Relation in the concept rubric above.");
        sb.AppendLine("All KPs and KRs must appear in the output, even if not addressed.");
        sb.AppendLine();

        sb.AppendLine("Use this scale for Key Propositions:");
        sb.AppendLine("  -1 (Incorrect): The opposite of what is true, or so unrelated it signals clear misunderstanding.");
        sb.AppendLine("   0 (Missing): Not present, or stated so vaguely it conveys nothing useful.");
        sb.AppendLine("   1 (Vague): Present but imprecise or incomplete — too broad, omits a critical qualifier,");
        sb.AppendLine("              or a reader who didn't already know the concept could not reconstruct it from this statement alone.");
        sb.AppendLine("   2 (Adequate): Clearly and correctly stated. Specific enough to distinguish it from adjacent or general concepts.");
        sb.AppendLine();

        sb.AppendLine("Use this scale for Key Relations:");
        sb.AppendLine("  -1 (Incorrect): The opposite of what is true, or so unrelated it signals clear misunderstanding.");
        sb.AppendLine("   0 (Missing): The causal or conditional link between the two propositions is absent.");
        sb.AppendLine("   1 (Vague): Both propositions mentioned in proximity, but the mechanism connecting them");
        sb.AppendLine("              is not expressed — the learner lists rather than relates.");
        sb.AppendLine("   2 (Adequate): The mechanism is explicitly stated: why or under what condition one proposition");
        sb.AppendLine("                 determines or constrains the other.");
        sb.AppendLine();

        sb.AppendLine("Score only what is explicitly written. Do not infer or credit implied content.");
        sb.AppendLine("Evaluate concepts, not language. Grammar and style must not reduce scores.");
        sb.AppendLine("Resist sycophancy. Evaluate strictly against the rubric.");
        sb.AppendLine();

        if (record.CommonMisconceptions.Count != 0)
        {
            sb.AppendLine("# Misconception detection");
            sb.AppendLine("Flag a misconception if the learner's text contains reasoning or claims that reflect that");
            sb.AppendLine("misunderstanding, even if the learner also states something correct nearby.");
            sb.AppendLine("List the keys of any known misconceptions triggered in this Elaboration.");
            sb.AppendLine();
        }

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
