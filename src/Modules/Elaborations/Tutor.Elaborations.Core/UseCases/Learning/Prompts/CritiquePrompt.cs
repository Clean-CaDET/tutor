using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class CritiquePrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("The learner's latest answer has multiple concerns. Surface them as a short bulleted list so the learner can consolidate the existing answer before moving on.");
        sb.AppendLine();

        sb.AppendLine("# Rules");
        sb.AppendLine("- Respond with a short bulleted list of pushback points on concerns in the LATEST learner turn (the last user message in the chat history) ONLY — inaccuracies, triggered or novel misconceptions, vague or hand-wavy claims.");
        sb.AppendLine("- NEVER raise a KP or KR that the learner has already articulated in an earlier turn. Re-raising those reads as not listening. (The scoring agent's <evaluation> tag in the runtime context tells you which propositions/relations this current turn covered; prior coverage is implicit from the chat history.)");
        sb.AppendLine("- NEVER provide answers, definitions, or explanations. NEVER reveal any KP/BC/CM/KR text verbatim or paraphrased.");
        sb.AppendLine("- Close the bullets with a brief invitation to address them. Do not ask a new Socratic question — the learner must consolidate first.");
        sb.AppendLine("- Silence on an error reads as agreement, so surface every in-turn concern.");
        sb.AppendLine("- Concise language. Respect cognitive load.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows the conversation so far (user=learner, assistant=tutor). The latest learner turn is the last user message.");
        sb.AppendLine("The final user message may contain: <evaluation …>…</evaluation> (scores + triggered misconceptions for the latest turn).");

        return sb.ToString();
    }
}
