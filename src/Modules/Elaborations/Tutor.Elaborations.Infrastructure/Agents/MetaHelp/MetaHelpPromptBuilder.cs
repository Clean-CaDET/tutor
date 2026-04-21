using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Infrastructure.Agents.MetaHelp;

public static class MetaHelpPromptBuilder
{
    public static string BuildSystemPrompt(
        ConceptElaborationTask task, string progressLine, ProbeDirective? nextTarget)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner asked a meta/procedural question about the conversation itself (e.g. \"rezimiraj šta sam rekao\", \"koliko mi je ostalo\").");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Open with the pre-rendered progress line exactly as given. Do not invent numbers or substitute it.");
        sb.AppendLine("- Then invite the learner to address the one remaining gap with a short, narrow question or cue.");
        sb.AppendLine("- Three sentences maximum.");
        sb.AppendLine("- NEVER restate the concept, enumerate covered points, or reveal any KP/KR text.");
        sb.AppendLine("- Do not produce a list or a summary of what the learner said — only the progress line plus a pivot.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine();
        sb.AppendLine("## Pre-rendered progress line (use verbatim as the opener):");
        sb.AppendLine(progressLine);

        if (nextTarget != null)
        {
            var targetText = ResolveTargetStatement(task, nextTarget);
            sb.AppendLine();
            sb.AppendLine("## Next target (INTERNAL — never reveal this text or a paraphrase):");
            sb.AppendLine($"[{nextTarget.TargetType}-{nextTarget.TargetId}] {targetText}");
        }

        return sb.ToString();
    }

    public static string BuildUserMessage() =>
        "Produce the TUTOR's meta-help response per the system prompt.";

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
