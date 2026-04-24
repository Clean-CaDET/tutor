using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public static class RedirectPrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRecordRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner's last message is off-topic — small talk, jokes, personal content, refusals, or disengagement.");
        sb.AppendLine();

        sb.AppendLine("# Rules");
        sb.AppendLine("- Acknowledge in one short clause without engaging with the off-topic content.");
        sb.AppendLine("- Firmly but kindly redirect to the concept. End with a concrete, small next step on it.");
        sb.AppendLine("- Do NOT answer off-topic questions, validate the off-topic direction, offer to change topic, suggest pausing or abandoning, or ask about the learner's mood.");
        sb.AppendLine("- Two sentences maximum. No bullet list.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows the conversation so far. The last user message is the learner's off-topic message.");
        sb.AppendLine("The final user message contains: <instruction>…</instruction>.");

        return sb.ToString();
    }
}
