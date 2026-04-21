using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Closing;

public static class ClosingPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task, ClosingReason reason)
    {
        var header = reason == ClosingReason.AllCovered
            ? "## The learner has covered all required propositions and articulated all required relations."
            : "## The conversation has reached its maximum length.";
        var ack = reason == ClosingReason.AllCovered
            ? "Acknowledge completion in general terms only (e.g., \"dobro si obuhvatio koncept\")."
            : "Acknowledge that the conversation is ending in general terms only.";

        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine();
        sb.AppendLine(header);
        sb.AppendLine("Produce a closing turn with exactly these properties:");
        sb.AppendLine("- Two sentences maximum.");
        sb.AppendLine($"- {ack}");
        sb.AppendLine("- DO NOT summarize the learner's explanation or the concept.");
        sb.AppendLine("- DO NOT list, restate, or paraphrase any key proposition, boundary condition, or relation — not even ones already articulated.");
        sb.AppendLine("- DO NOT use bullet points or structured lists.");
        sb.AppendLine("- DO NOT ask further questions.");
        sb.AppendLine("The summary agent writes the summary separately; your job here is only to close the dialogue.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        return sb.ToString();
    }

    public static string BuildUserMessage() =>
        "Produce the TUTOR's closing turn per the system prompt.";
}
