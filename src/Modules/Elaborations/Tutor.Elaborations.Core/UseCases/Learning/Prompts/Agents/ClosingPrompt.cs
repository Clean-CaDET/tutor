using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public static class ClosingPrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRecordRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("Produce a closing turn that ends the conversation. The reason for closing is given in the <instruction> of the runtime context.");
        sb.AppendLine();

        sb.AppendLine("# Rules");
        sb.AppendLine("- Two sentences maximum.");
        sb.AppendLine("- If the instruction says the learner covered everything (reason=AllCovered), acknowledge completion in general terms (e.g. \"dobro si obuhvatio koncept\").");
        sb.AppendLine("- If the instruction says the conversation reached maximum length (reason=HardCapReached), acknowledge that the conversation is ending in general terms.");
        sb.AppendLine("- DO NOT summarize the learner's explanation or the concept. The summary agent writes the summary separately.");
        sb.AppendLine("- DO NOT list, restate, or paraphrase any KP/BC/CM/KR — not even ones already articulated.");
        sb.AppendLine("- DO NOT use bullet points or structured lists.");
        sb.AppendLine("- DO NOT ask further questions.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows the full conversation.");
        sb.AppendLine("The final user message contains: <instruction>…</instruction> (carries reason=AllCovered or reason=HardCapReached).");

        return sb.ToString();
    }
}
