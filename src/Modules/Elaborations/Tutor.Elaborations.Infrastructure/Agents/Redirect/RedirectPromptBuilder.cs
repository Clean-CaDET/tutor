using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Infrastructure.Agents.Redirect;

public static class RedirectPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner's last message is off-topic — small talk, jokes, personal content, refusals, or disengagement.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Acknowledge in one short clause without engaging with the off-topic content.");
        sb.AppendLine("- Firmly but kindly redirect to the concept. End with a concrete, small next step on it.");
        sb.AppendLine("- Do NOT answer off-topic questions, validate the off-topic direction, offer to change topic, suggest pausing or abandoning, or ask about the learner's mood.");
        sb.AppendLine("- Two sentences maximum. No bullet list.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        return sb.ToString();
    }

    public static string BuildUserMessage() =>
        "Produce the TUTOR's redirect per the system prompt.";
}
