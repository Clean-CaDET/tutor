using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public static class SummaryPrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRecordRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a summary agent. Write a brief natural-language summary of the conversation.");
        sb.AppendLine("Paraphrase what the learner demonstrated understanding of. Never quote proposition or relation statements verbatim.");
        sb.AppendLine("Write in Serbian. Keep the summary to 2-4 sentences.");
        sb.AppendLine();

        sb.AppendLine("# Rules");
        sb.AppendLine("- Base the summary on the learner's actual turns in the chat history, not on the KP list.");
        sb.AppendLine("- Paraphrase at the level of the learner's articulations; do not upgrade them with rubric language.");
        sb.AppendLine("- NEVER quote any KP/BC/CM/KR text verbatim or near-verbatim.");
        sb.AppendLine("- No bullet lists. One short paragraph, 2-4 sentences.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows the full conversation (user=learner, assistant=tutor).");
        sb.AppendLine("The final user message contains: <instruction>…</instruction>.");

        return sb.ToString();
    }
}
