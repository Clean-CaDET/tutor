using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Infrastructure.Agents.Clarification;

public static class ClarificationPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task, ProbeDirective? lastProbe)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner has asked a clarifying question. Rephrase or clarify the TUTOR's prior question in simpler language. Do NOT answer it — answering defeats the whole exercise.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Max three sentences. Address only the specific thing asked.");
        sb.AppendLine("- If the learner says they don't understand, rephrase the TUTOR's prior question in simpler terms. Do not answer the question under the guise of rephrasing.");
        sb.AppendLine("- If the learner asks for a summary, \"the answer\", an explanation, or anything that would require producing the concept's content, REFUSE and redirect: \"Rezime i objašnjenje moraju doći od tebe — to je ono što vežbamo. Pokušaj da formulišeš svojim rečima.\"");
        sb.AppendLine("- NEVER state or paraphrase the target below. The whole point is that the learner articulates it.");
        sb.AppendLine("- NEVER produce a list or multi-sentence breakdown.");
        sb.AppendLine("- After clarifying, invite the learner to resume with one short prompt.");

        if (lastProbe != null)
        {
            var targetText = ResolveTargetStatement(task, lastProbe);
            sb.AppendLine();
            sb.AppendLine("## What the TUTOR was probing (INTERNAL — NEVER reveal this text or a paraphrase close enough to give away the answer):");
            sb.AppendLine($"[{lastProbe.TargetType}-{lastProbe.TargetId}] {targetText}");
        }

        return sb.ToString();
    }

    public static string BuildUserMessage(List<ConversationTurn> history, string learnerContent)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Conversation so far");
        foreach (var turn in history)
        {
            var label = turn.Role == TurnRole.Learner ? "LEARNER" : "TUTOR";
            sb.AppendLine($"[{label}]: {turn.Content}");
        }
        sb.AppendLine();
        sb.AppendLine("## Latest LEARNER message (the clarification request)");
        sb.AppendLine(learnerContent);
        sb.AppendLine();
        sb.AppendLine("Produce the TUTOR's clarification per the system prompt.");
        return sb.ToString();
    }

    private static string ResolveTargetStatement(ConceptElaborationTask task, ProbeDirective directive)
    {
        if (directive.TargetType == ProbeTargetType.KeyProposition)
        {
            var kp = task.KeyPropositions.FirstOrDefault(p => p.Id == directive.TargetId);
            return kp?.Statement ?? "(unknown)";
        }
        var kr = task.KeyRelations.FirstOrDefault(r => r.Id == directive.TargetId);
        if (kr == null) return "(unknown)";
        var kpById = task.KeyPropositions.ToDictionary(p => p.Id, p => p.Statement);
        var source = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, "?");
        var target = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, "?");
        return $"{source} → {target}. Mechanism: {kr.Mechanism}";
    }
}
