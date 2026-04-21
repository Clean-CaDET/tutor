using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.IntentClassifier;

public static class IntentPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are an intent classifier for a Socratic tutoring conversation.");
        sb.AppendLine("Classify the learner's latest message into exactly one intent. Output JSON only, no other text.");
        sb.AppendLine();
        sb.AppendLine($"## Concept under study: {task.Title}");
        sb.AppendLine();
        sb.AppendLine("## Intent categories:");
        sb.AppendLine("- **Substantive**: the learner attempts to explain, define, relate, or apply the concept. Even a weak or partial attempt counts.");
        sb.AppendLine("- **Clarification**: the learner asks a genuine information-seeking question about the task or the tutor's last message (what / why / how / what do you mean by …?). Must be a direct question — if removing the rest and keeping just the question still makes sense.");
        sb.AppendLine("- **Stuck**: the learner signals confusion, inability, or not-knowing without asking a question — e.g. \"ne znam\", \"ne razumem\", \"nisam siguran\", \"teško mi je\". Not a refusal of the task, just a stall.");
        sb.AppendLine("- **MetaHelp**: the learner asks a procedural/meta question about the conversation itself — e.g. \"rezimiraj šta sam rekao\", \"koliko mi je ostalo\", \"objasni mi još jednom šta tražiš\".");
        sb.AppendLine("- **OffTopic**: everything else — small talk, greetings, jokes, personal content, refusals (\"ne želim\", \"dosadno mi je\"), meta-comments about the conversation, deference or agreement without articulation (\"da, u pravu si\").");
        sb.AppendLine();
        sb.AppendLine("## Disambiguation rules:");
        sb.AppendLine("- If the message is a verbatim or near-verbatim echo of a previous [TUTOR] line, classify as OffTopic.");
        sb.AppendLine("- Between Clarification and Stuck: if the message is a question, Clarification; if it is a statement of not-knowing, Stuck.");
        sb.AppendLine("- Between Clarification and MetaHelp: MetaHelp is about the conversation/progress itself; Clarification is about the concept or the tutor's last probe.");
        sb.AppendLine("- When in doubt between Clarification and OffTopic, choose OffTopic.");
        sb.AppendLine();
        sb.AppendLine("## Output format (JSON, no other text):");
        sb.AppendLine("{ \"intent\": \"Substantive\" | \"Clarification\" | \"Stuck\" | \"MetaHelp\" | \"OffTopic\" }");
        return sb.ToString();
    }

    public static string BuildUserMessage(string learnerContent, List<ConversationTurn> history)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Conversation so far (for context — do NOT classify these)");
        if (history.Count == 0)
        {
            sb.AppendLine("(no prior turns)");
        }
        else
        {
            foreach (var turn in history.TakeLast(6))
            {
                var label = turn.Role == TurnRole.Learner ? "LEARNER" : "TUTOR";
                sb.AppendLine($"[{label}]: {turn.Content}");
            }
        }
        sb.AppendLine();
        sb.AppendLine("## Message to classify (this is the ONLY message to classify)");
        sb.AppendLine($"[LEARNER]: {learnerContent}");
        return sb.ToString();
    }
}
