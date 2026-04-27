using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public static class IntentPrompt
{
    public static string Build(ConceptRecord record)
    {
        var sb = new StringBuilder();
        sb.AppendLine(ConceptRecordRubricSection.Render(record));

        sb.AppendLine("# Role");
        sb.AppendLine("You are an intent classifier for a Socratic tutoring conversation.");
        sb.AppendLine("Classify the learner's latest message into exactly one intent. Output JSON only, no other text.");
        sb.AppendLine();

        sb.AppendLine("# Intent categories");
        sb.AppendLine("- **Substantive**: the learner attempts to explain, define, relate, or apply the concept. Even a weak or partial attempt counts.");
        sb.AppendLine("- **Clarification**: the learner asks a genuine information-seeking question about the task or the tutor's last message (what / why / how / what do you mean by …?). Must be a direct question — if removing the rest and keeping just the question still makes sense.");
        sb.AppendLine("- **Stuck**: the learner signals confusion, inability, or not-knowing without asking a question — e.g. \"ne znam\", \"ne razumem\", \"nisam siguran\", \"teško mi je\". Not a refusal of the task, just a stall.");
        sb.AppendLine("- **SummaryRequest**: the learner asks a procedural/meta question about the conversation itself — e.g. \"rezimiraj šta sam rekao\", \"koliko mi je ostalo\", \"objasni mi još jednom šta tražiš\".");
        sb.AppendLine("- **OffTopic**: everything else — small talk, greetings, jokes, personal content, refusals (\"ne želim\", \"dosadno mi je\"), meta-comments about the conversation, deference or agreement without articulation (\"da, u pravu si\").");
        sb.AppendLine();

        sb.AppendLine("# Disambiguation rules");
        sb.AppendLine("- If the message is a verbatim or near-verbatim echo of a previous assistant line, classify as OffTopic.");
        sb.AppendLine("- Between Clarification and Stuck: if the message is a question, Clarification; if it is a statement of not-knowing, Stuck.");
        sb.AppendLine("- Between Clarification and SummaryRequest: SummaryRequest is about the conversation/progress itself; Clarification is about the concept or the tutor's last probe.");
        sb.AppendLine("- When in doubt between Clarification and OffTopic, choose OffTopic.");
        sb.AppendLine();

        sb.AppendLine("# Runtime Context Format");
        sb.AppendLine("Chat history shows prior turns (user=learner, assistant=tutor) for context only — DO NOT classify these.");
        sb.AppendLine("The final user message contains the message to classify inside <current-learner-message>…</current-learner-message>.");
        sb.AppendLine();

        sb.AppendLine("# Output Format");
        sb.AppendLine("JSON only, no other text:");
        sb.AppendLine("{ \"intent\": \"Substantive\" | \"Clarification\" | \"Stuck\" | \"SummaryRequest\" | \"OffTopic\" }");

        return sb.ToString();
    }
}
