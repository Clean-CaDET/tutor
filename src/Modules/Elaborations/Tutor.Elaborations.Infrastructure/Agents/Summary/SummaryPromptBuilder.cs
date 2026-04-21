using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Summary;

public static class SummaryPromptBuilder
{
    public static string BuildSystemPrompt(ConversationAttempt attempt, ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a summary agent. Write a brief natural-language summary of the conversation.");
        sb.AppendLine("Paraphrase what the learner demonstrated understanding of. Never quote proposition statements verbatim.");
        sb.AppendLine("Write in Serbian. Keep the summary to 2-4 sentences.");
        sb.AppendLine();
        sb.AppendLine($"Concept: {task.Title}");

        var coveredIds = attempt.GetCoveredPropositionIds();
        var covered = task.KeyPropositions.Where(kp => coveredIds.Contains(kp.Id)).ToList();
        if (covered.Count > 0)
        {
            sb.AppendLine("Propositions the learner covered (paraphrase, do not quote):");
            foreach (var kp in covered)
                sb.AppendLine($"- {kp.Statement}");
        }

        return sb.ToString();
    }

    public static string BuildTranscript(ConversationAttempt attempt)
    {
        var sb = new StringBuilder();
        foreach (var turn in attempt.Turns.OrderBy(t => t.Order))
        {
            var role = turn.Role == TurnRole.Learner ? "Learner" : "System";
            sb.AppendLine($"{role}: {turn.Content}");
        }
        return sb.ToString();
    }
}
