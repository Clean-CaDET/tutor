using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Infrastructure.Agents.Probe;

public static class ProbePromptBuilder
{
    public static string BuildSystemPrompt(
        ConceptElaborationTask task, ProbeDirective directive, bool isSoftCapReached)
    {
        var targetText = ResolveTargetStatement(task, directive);

        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("Ask ONE question that probes the single target below. Do not reveal the target text, do not list alternatives, do not summarize what the learner has said.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();
        sb.AppendLine("## Target (INTERNAL — never reveal this text or a paraphrase):");
        sb.AppendLine($"[{directive.TargetType}-{directive.TargetId}] {targetText}");
        sb.AppendLine();
        sb.AppendLine($"## Escalation level: L{directive.Level}");
        sb.AppendLine(directive.Level switch
        {
            1 => "L1 — open \"why\" or \"what\" question that invites the learner to articulate the target. Broad enough to let them arrive at the idea themselves.",
            2 => "L2 — the learner has already failed an L1 probe on this target. Ask a narrower, connective question: \"how is X tied to Y\", \"what role does X play when Y\". Still no hints to the target statement.",
            3 => "L3 — the learner has failed twice. Offer a sentence-completion scaffold: \"Dopuni rečenicu: '…zato što…'\" or \"Dovrši misao: …\". The blank must not contain the target text.",
            _ => "Open question at the lowest level."
        });
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Output ONE question (or one sentence-completion prompt at L3). No preamble, no bullet list.");
        sb.AppendLine("- NEVER reveal the target statement or a paraphrase close enough to give away the answer.");
        sb.AppendLine("- NEVER list multiple options or enumerate gaps.");
        sb.AppendLine("- Concise. Respect cognitive load.");
        if (isSoftCapReached)
        {
            sb.AppendLine();
            sb.AppendLine("## The learner is approaching the end of the conversation. Signal that you'll wrap up once this is addressed.");
        }
        return sb.ToString();
    }

    public static string BuildUserMessage(List<ConversationTurn> history)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Conversation so far");
        if (history.Count == 0)
        {
            sb.AppendLine("(no prior turns)");
        }
        else
        {
            foreach (var turn in history)
            {
                var label = turn.Role == TurnRole.Learner ? "LEARNER" : "TUTOR";
                sb.AppendLine($"[{label}]: {turn.Content}");
            }
        }
        sb.AppendLine();
        sb.AppendLine("Produce the TUTOR's next probe question per the system prompt.");
        return sb.ToString();
    }

    private static string ResolveTargetStatement(ConceptElaborationTask task, ProbeDirective directive)
    {
        if (directive.TargetType == ProbeTargetType.KeyProposition)
        {
            var kp = task.KeyPropositions.FirstOrDefault(p => p.Id == directive.TargetId);
            return kp?.Statement ?? "(unknown proposition)";
        }

        var kr = task.KeyRelations.FirstOrDefault(r => r.Id == directive.TargetId);
        if (kr == null) return "(unknown relation)";
        var kpById = task.KeyPropositions.ToDictionary(p => p.Id, p => p.Statement);
        var source = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, "?");
        var target = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, "?");
        return $"{source} → {target}. Mechanism: {kr.Mechanism}";
    }
}
