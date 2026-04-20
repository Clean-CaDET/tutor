using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Infrastructure.Agents.Prompts;

public static class DialoguePromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task, ConversationAttempt attempt, TurnAnalysis analysis)
    {
        return analysis.Intent switch
        {
            TurnIntent.Clarification => BuildClarificationPrompt(task),
            TurnIntent.OffTopic => BuildOffTopicPrompt(task),
            _ => analysis.HasMultipleConcerns
                ? BuildFixModePrompt(task, attempt)
                : BuildProbeModePrompt(task, attempt)
        };
    }

    private static string BuildFixModePrompt(ConceptElaborationTask task, ConversationAttempt attempt)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("The learner's latest answer has multiple concerns. Your job is to surface them so the learner can consolidate their existing answer before moving on.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- NEVER provide answers, definitions, or explanations, and NEVER reveal key proposition, boundary condition, or misconception text.");
        sb.AppendLine("- Respond with ONLY a short bulleted list pushing back on each concern in the learner's latest answer — inaccuracies, triggered or novel misconceptions, and vague or hand-wavy claims. Close the bullets with a brief invitation to address them.");
        sb.AppendLine("- Do NOT ask a new question about an uncovered key proposition or key relation — the learner must consolidate what they said before expanding.");
        sb.AppendLine("- Silence on an error reads as agreement, so surface every concern.");
        sb.AppendLine("- Concise language. Respect cognitive load.");
        sb.AppendLine();

        AppendConceptReference(sb, task);

        if (attempt.IsSoftCapReached())
        {
            sb.AppendLine("## The learner is approaching the end of the conversation.");
            sb.AppendLine("Close the bullets with a note that you'll wrap up once these concerns are addressed.");
        }
        return sb.ToString();
    }

    private static string BuildProbeModePrompt(ConceptElaborationTask task, ConversationAttempt attempt)
    {
        if (task.IsAttemptComplete(attempt))
            return BuildClosedDialoguePrompt(task,
                "## The learner has covered all required propositions and articulated all required relations.",
                "Acknowledge completion in general terms only (e.g., \"dobro si obuhvatio koncept\").");

        if (attempt.IsHardCapReached())
            return BuildClosedDialoguePrompt(task,
                "## The conversation has reached its maximum length.",
                "Acknowledge that the conversation is ending in general terms only.");

        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine("Guide the learner to explain the concept by asking targeted questions.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- NEVER provide answers, definitions, or explanations, and NEVER reveal key proposition, boundary condition, or misconception text.");
        sb.AppendLine("- If the evaluation reports a single concern (inaccuracy, triggered or novel misconception, or vague claim), push back on it in one short line BEFORE your Socratic question. If there is no concern, skip the pushback.");
        sb.AppendLine("- Ask ONE Socratic question about a single uncovered key proposition or unarticulated key relation. Do not list remaining gaps.");
        sb.AppendLine("- Concise language. Respect cognitive load. Allow productive divergence within the concept space.");
        sb.AppendLine();

        AppendConceptReference(sb, task);

        var uncoveredKpIds = task.GetUncoveredPropositionIds(attempt);
        var unarticulatedKrIds = task.GetUnarticulatedRelationIds(attempt);
        var hasGaps = uncoveredKpIds.Any() || unarticulatedKrIds.Any();

        if (hasGaps)
        {
            sb.AppendLine("## Uncovered ground (pick ONE to probe):");
            if (uncoveredKpIds.Any())
                sb.AppendLine($"- Uncovered key propositions: {string.Join(", ", uncoveredKpIds.Select(id => $"KP-{id}"))}");
            if (unarticulatedKrIds.Any())
                sb.AppendLine($"- Unarticulated key relations: {string.Join(", ", unarticulatedKrIds.Select(id => $"KR-{id}"))}");
            sb.AppendLine("Never reveal the underlying statement or mechanism text.");
            sb.AppendLine();
        }

        if (attempt.IsSoftCapReached())
        {
            sb.AppendLine("## The learner is approaching the end of the conversation.");
            sb.AppendLine(hasGaps
                ? "Suggest wrapping up. Focus the Socratic question on the most important uncovered gap above."
                : "Suggest wrapping up. Use the Socratic question to briefly probe whatever feels least articulated so far.");
        }
        return sb.ToString();
    }

    private static string BuildClosedDialoguePrompt(ConceptElaborationTask task, string header, string acknowledgmentLine)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring agent. Speak Serbian.");
        sb.AppendLine();
        sb.AppendLine(header);
        sb.AppendLine("Produce a closing turn with exactly these properties:");
        sb.AppendLine("- Two sentences maximum.");
        sb.AppendLine($"- {acknowledgmentLine}");
        sb.AppendLine("- DO NOT summarize the learner's explanation or the concept.");
        sb.AppendLine("- DO NOT list, restate, or paraphrase any key proposition, boundary condition, or relation — not even ones already articulated.");
        sb.AppendLine("- DO NOT use bullet points or structured lists.");
        sb.AppendLine("- DO NOT ask further questions.");
        sb.AppendLine("The summary agent will write the summary separately; your job here is only to close the dialogue.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        return sb.ToString();
    }

    private static string BuildClarificationPrompt(ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner has asked a clarifying question. Answer it using ONLY the reference below.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Answer is MAX three sentences. Address only the specific thing asked — do not expand.");
        sb.AppendLine("- If the learner asks for a summary, \"the answer\", an explanation, or anything that would require producing the concept's content, REFUSE and redirect. Example: \"Rezime mora da dođe od tebe — to je ono što vežbamo. Pokušaj da formulišeš u svojim rečima.\"");
        sb.AppendLine("- NEVER produce a list or multi-sentence breakdown.");
        sb.AppendLine("- After answering, invite the learner to resume elaboration with one short prompt.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Question: {task.CanonicalDefinition}");
        sb.AppendLine();

        return sb.ToString();
    }

    private static string BuildOffTopicPrompt(ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic tutoring assistant. Speak Serbian.");
        sb.AppendLine("The learner's last message is off-topic — small talk, jokes, personal content, refusals, or disengagement.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Acknowledge in one short clause without engaging with the off-topic content.");
        sb.AppendLine("- Firmly but kindly redirect to the concept. End with a concrete, small next step on it.");
        sb.AppendLine("- Do NOT answer off-topic questions, validate the off-topic direction, offer to change topic, suggest pausing or abandoning, or ask about the learner's mood.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        return sb.ToString();
    }

    private static void AppendConceptReference(StringBuilder sb, ConceptElaborationTask task)
    {
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();
        sb.AppendLine("The reference blocks below are for your use only. Never reveal any statement or mechanism text verbatim or paraphrased.");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions:");
        foreach (var kp in task.KeyPropositions)
            sb.AppendLine($"- [KP-{kp.Id}] {kp.Statement}");
        sb.AppendLine();

        if (task.BoundaryConditions.Count != 0)
        {
            sb.AppendLine("## Boundary Conditions:");
            foreach (var bc in task.BoundaryConditions)
                sb.AppendLine($"- [BC-{bc.Id}] {bc.Statement}");
            sb.AppendLine();
        }

        if (task.CommonMisconceptions.Count != 0)
        {
            sb.AppendLine("## Common Misconceptions:");
            foreach (var cm in task.CommonMisconceptions)
                sb.AppendLine($"- [CM-{cm.Id}] {cm.Description} (correction: {cm.Correction})");
            sb.AppendLine();
        }

        if (task.KeyRelations.Count != 0)
        {
            sb.AppendLine("## Key Relations:");
            var kpById = task.KeyPropositions.ToDictionary(kp => kp.Id, kp => kp.Statement);
            foreach (var kr in task.KeyRelations)
            {
                var sourceText = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, $"KP-{kr.SourceKeyPropositionId}");
                var targetText = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, $"KP-{kr.TargetKeyPropositionId}");
                sb.AppendLine($"- [KR-{kr.Id}] {sourceText} → {targetText}. Mechanism: {kr.Mechanism}");
            }
            sb.AppendLine();
        }
    }

    public static string BuildUserMessage(List<ConversationTurn> history, TurnAnalysis analysis)
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

        if (analysis.Intent == TurnIntent.Substantive && analysis.Evaluation != null)
        {
            sb.AppendLine("## Evaluation of the latest LEARNER turn (from the evaluation agent — NOT from the learner)");
            sb.AppendLine(BuildEvaluationSummaryBody(analysis.Evaluation));
            sb.AppendLine();
        }

        sb.AppendLine(analysis.Intent switch
        {
            TurnIntent.Clarification => "Produce the TUTOR's next turn per the system prompt. The latest LEARNER turn is a clarifying question.",
            TurnIntent.OffTopic      => "Produce the TUTOR's next turn per the system prompt. The latest LEARNER turn is off-topic and must be redirected.",
            _                        => "Produce the TUTOR's next turn per the system prompt, responding to the latest LEARNER turn."
        });

        return sb.ToString();
    }

    private static string BuildEvaluationSummaryBody(TurnEvaluation evaluation)
    {
        var parts = new List<string>
        {
            $"correctness={evaluation.CorrectnessScore}",
            $"completeness={evaluation.CompletenessScore}"
        };
        if (evaluation.DiscriminationScore.HasValue)
            parts.Add($"discrimination={evaluation.DiscriminationScore.Value}");
        if (evaluation.IntegrationScore.HasValue)
            parts.Add($"integration={evaluation.IntegrationScore.Value}");

        var sb = new StringBuilder();
        sb.AppendLine($"Scores: {string.Join(", ", parts)}");
        sb.AppendLine($"Justification: {evaluation.Justification}");
        if (evaluation.MisconceptionsTriggeredIds.Count != 0)
            sb.AppendLine($"Triggered misconceptions: {string.Join(", ", evaluation.MisconceptionsTriggeredIds.Select(id => $"CM-{id}"))}");
        if (!string.IsNullOrWhiteSpace(evaluation.NovelMisconceptions))
            sb.AppendLine($"Novel misconceptions: {evaluation.NovelMisconceptions}");
        return sb.ToString().TrimEnd();
    }
}
