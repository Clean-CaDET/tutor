using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Critique;

public static class CritiquePromptBuilder
{
    public static string BuildSystemPrompt(
        ConceptElaborationTask task, ConversationAttempt attempt, bool isSoftCapReached)
    {
        var coveredKpIds = attempt.GetCoveredPropositionIds();
        var articulatedKrIds = attempt.GetArticulatedRelationIds();

        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("The learner's latest answer has multiple concerns. Your job is to surface them as a short bulleted list so the learner can consolidate their existing answer before moving on.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions (internal reference — never quote verbatim):");
        foreach (var kp in task.KeyPropositions)
        {
            var marker = coveredKpIds.Contains(kp.Id) ? " [ALREADY ARTICULATED IN PRIOR TURN — DO NOT RAISE]" : "";
            sb.AppendLine($"- [KP-{kp.Id}]{marker} {kp.Statement}");
        }
        sb.AppendLine();

        if (task.BoundaryConditions.Count > 0)
        {
            sb.AppendLine("## Boundary Conditions (internal reference):");
            foreach (var bc in task.BoundaryConditions)
                sb.AppendLine($"- [BC-{bc.Id}] {bc.Statement}");
            sb.AppendLine();
        }

        if (task.CommonMisconceptions.Count > 0)
        {
            sb.AppendLine("## Common Misconceptions (internal reference):");
            foreach (var cm in task.CommonMisconceptions)
                sb.AppendLine($"- [CM-{cm.Id}] {cm.Description} (correction: {cm.Correction})");
            sb.AppendLine();
        }

        if (task.KeyRelations.Count > 0)
        {
            sb.AppendLine("## Key Relations (internal reference — never quote verbatim):");
            var kpById = task.KeyPropositions.ToDictionary(kp => kp.Id, kp => kp.Statement);
            foreach (var kr in task.KeyRelations)
            {
                var marker = articulatedKrIds.Contains(kr.Id) ? " [ALREADY ARTICULATED IN PRIOR TURN — DO NOT RAISE]" : "";
                var source = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, "?");
                var target = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, "?");
                sb.AppendLine($"- [KR-{kr.Id}]{marker} {source} → {target}. Mechanism: {kr.Mechanism}");
            }
            sb.AppendLine();
        }

        sb.AppendLine("## Rules:");
        sb.AppendLine("- Respond with a short bulleted list of pushback points on concerns in THE LATEST LEARNER TURN ONLY — inaccuracies, triggered or novel misconceptions, vague or hand-wavy claims.");
        sb.AppendLine("- NEVER raise a KP or KR marked ALREADY ARTICULATED. The learner has already said those in earlier turns; re-raising them reads as not listening.");
        sb.AppendLine("- NEVER provide answers, definitions, or explanations. NEVER reveal any KP/BC/CM/KR text verbatim or paraphrased.");
        sb.AppendLine("- Close the bullets with a brief invitation to address them. Do not ask a new Socratic question — the learner must consolidate first.");
        sb.AppendLine("- Silence on an error reads as agreement, so surface every in-turn concern.");
        sb.AppendLine("- Concise language. Respect cognitive load.");

        if (isSoftCapReached)
        {
            sb.AppendLine();
            sb.AppendLine("## The learner is approaching the end of the conversation. Signal that you'll wrap up once these are addressed.");
        }

        return sb.ToString();
    }

    public static string BuildUserMessage(
        TurnEvaluation evaluation, List<ConversationTurn> history)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Conversation so far");
        foreach (var turn in history)
        {
            var label = turn.Role == TurnRole.Learner ? "LEARNER" : "TUTOR";
            sb.AppendLine($"[{label}]: {turn.Content}");
        }
        sb.AppendLine();

        sb.AppendLine("## Evaluation of the latest LEARNER turn (from the scoring agent — NOT from the learner)");
        var parts = new List<string>
        {
            $"correctness={evaluation.CorrectnessScore}",
            $"completeness={evaluation.CompletenessScore}"
        };
        if (evaluation.DiscriminationScore.HasValue)
            parts.Add($"discrimination={evaluation.DiscriminationScore.Value}");
        if (evaluation.IntegrationScore.HasValue)
            parts.Add($"integration={evaluation.IntegrationScore.Value}");
        sb.AppendLine($"Scores: {string.Join(", ", parts)}");
        sb.AppendLine($"Justification: {evaluation.Justification}");
        if (evaluation.MisconceptionsTriggeredIds.Count != 0)
            sb.AppendLine($"Triggered misconceptions: {string.Join(", ", evaluation.MisconceptionsTriggeredIds.Select(id => $"CM-{id}"))}");
        if (!string.IsNullOrWhiteSpace(evaluation.NovelMisconceptions))
            sb.AppendLine($"Novel misconceptions: {evaluation.NovelMisconceptions}");
        sb.AppendLine();

        sb.AppendLine("Produce the TUTOR's critique of the latest LEARNER turn per the system prompt.");
        return sb.ToString();
    }
}
