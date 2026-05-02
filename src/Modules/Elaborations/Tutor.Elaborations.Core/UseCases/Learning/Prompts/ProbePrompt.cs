using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class ProbePrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("Ask ONE question that probes the target given in the runtime context. Do not reveal the target text, do not list alternatives, do not summarize what the learner has said.");
        sb.AppendLine();

        sb.AppendLine("# Escalation levels");
        sb.AppendLine("The <target> tag carries a level attribute (1-2) that shapes the question:");
        sb.AppendLine("- L1 — open \"why\" or \"what\" question that invites the learner to articulate the target. Broad enough to let them arrive at the idea themselves.");
        sb.AppendLine("- L2 — the learner has already failed an L1 probe on this target. Ask a narrower, connective question: \"how is X tied to Y\", \"what role does X play when Y\". Still no hints to the target statement.");
        sb.AppendLine();

        sb.AppendLine("# Rules");
        sb.AppendLine("- The <target> statement is INTERNAL — NEVER reveal or paraphrase it closely enough to give away the answer.");
        sb.AppendLine("- Output ONE question. No preamble, no bullet list.");
        sb.AppendLine("- NEVER list multiple options or enumerate gaps.");
        sb.AppendLine("- Concise. Respect cognitive load.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows the conversation so far (user=learner, assistant=tutor).");
        sb.AppendLine("The final user message contains: <target level=\"1-2\">…statement…</target>.");

        return sb.ToString();
    }
}
