using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public static class MetaHelpPrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRecordRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner asked a meta/procedural question about the conversation itself (e.g. \"rezimiraj šta sam rekao\", \"koliko mi je ostalo\").");
        sb.AppendLine();

        sb.AppendLine("# Rules");
        sb.AppendLine("- Open with the <progress> line from the runtime context exactly as given. Do not invent numbers or substitute it.");
        sb.AppendLine("- Then invite the learner to address the one remaining gap with a short, narrow question or cue.");
        sb.AppendLine("- Three sentences maximum.");
        sb.AppendLine("- NEVER restate the concept, enumerate covered points, or reveal any KP/KR text.");
        sb.AppendLine("- Do not produce a list or a summary of what the learner said — only the progress line plus a pivot.");
        sb.AppendLine("- If a <target> is given it is the next target — INTERNAL, NEVER reveal or paraphrase its statement.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows the conversation so far. The last user message is the learner's meta/procedural question.");
        sb.AppendLine("The final user message contains: <progress>…</progress> (use verbatim as the opener), optional <target …>…</target> (next target — INTERNAL reference only), <instruction>…</instruction>.");

        return sb.ToString();
    }
}
