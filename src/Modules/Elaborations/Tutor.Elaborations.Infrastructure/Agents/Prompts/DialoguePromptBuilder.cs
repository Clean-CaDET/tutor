using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Prompts;

public static class DialoguePromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task, ConversationAttempt attempt, TurnIntent intent)
    {
        return intent switch
        {
            TurnIntent.Clarification => BuildClarificationPrompt(task),
            TurnIntent.OffTopic => BuildOffTopicPrompt(task),
            _ => BuildSubstantivePrompt(task, attempt)
        };
    }

    private static string BuildSubstantivePrompt(ConceptElaborationTask task, ConversationAttempt attempt)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a Socratic dialogue agent for a tutoring system. You speak Serbian.");
        sb.AppendLine("Your role: guide the learner to explain a concept by asking targeted questions.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- NEVER provide answers, definitions, or explanations.");
        sb.AppendLine("- NEVER reveal key propositions, boundary conditions, or misconception text.");
        sb.AppendLine("- Every response: acknowledge → identify gap → ask targeted question.");
        sb.AppendLine("- Use concise language. Respect cognitive load.");
        sb.AppendLine("- Allow productive divergence within the concept space.");
        sb.AppendLine();

        AppendConceptReference(sb, task);
        sb.AppendLine(BuildSubstantiveClosing(task, attempt));
        return sb.ToString();
    }

    private static string BuildClarificationPrompt(ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a tutoring assistant helping a learner during a Socratic elaboration task. You speak Serbian.");
        sb.AppendLine("The learner has asked a clarifying question. Answer it directly using the reference material below.");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Keep the answer brief and focused on the learner's question.");
        sb.AppendLine("- You MAY use the definition, boundary conditions, and general framing to answer.");
        sb.AppendLine("- NEVER directly reveal key propositions or key-relation mechanism text — those are what the learner must articulate themselves.");
        sb.AppendLine("- After answering, invite the learner to resume their elaboration with one short prompt.");
        sb.AppendLine();

        AppendConceptReference(sb, task);
        return sb.ToString();
    }

    private static string BuildOffTopicPrompt(ConceptElaborationTask task)
    {
        var sb = new StringBuilder();
        sb.AppendLine("You are a tutoring assistant helping a learner during a Socratic elaboration task. You speak Serbian.");
        sb.AppendLine("The learner's message is off-topic for this task. This includes small talk, jokes, personal questions, and refusals or disengagement (e.g., \"I don't feel like it\", \"this is boring\").");
        sb.AppendLine();
        sb.AppendLine("## Rules:");
        sb.AppendLine("- Acknowledge very briefly (one short clause) without engaging with the off-topic content.");
        sb.AppendLine("- Firmly but kindly redirect the learner back to elaborating the concept. End with a concrete prompt tied to the concept.");
        sb.AppendLine("- Do NOT answer off-topic questions, comment on unrelated material, or validate the off-topic direction.");
        sb.AppendLine("- Do NOT offer to change the topic, discuss something else, or pause the session. If the learner wants to stop, they can use the abandon option themselves — do not suggest it.");
        sb.AppendLine("- Do NOT ask how the learner is feeling or explore their mood.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine("Remind the learner of the concept they are elaborating and give them a concrete, small next step on it.");
        return sb.ToString();
    }

    private static void AppendConceptReference(StringBuilder sb, ConceptElaborationTask task)
    {
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions (for your reference only, never reveal):");
        foreach (var kp in task.KeyPropositions)
            sb.AppendLine($"- [KP-{kp.Id}] {kp.Statement}");
        sb.AppendLine();

        if (task.BoundaryConditions.Count != 0)
        {
            sb.AppendLine("## Boundary Conditions (non-examples you may reference when clarifying):");
            foreach (var bc in task.BoundaryConditions)
                sb.AppendLine($"- [BC-{bc.Id}] {bc.Statement}");
            sb.AppendLine();
        }

        if (task.KeyRelations.Count != 0)
        {
            sb.AppendLine("## Key Relations (for your reference only, never reveal the mechanism text):");
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

    private static string BuildSubstantiveClosing(ConceptElaborationTask task, ConversationAttempt attempt)
    {
        var sb = new StringBuilder();
        if (task.IsAttemptComplete(attempt))
        {
            sb.AppendLine("## The learner has covered all required propositions and articulated all required relations.");
            sb.AppendLine("Provide a brief closing acknowledgment. Do not ask more questions.");
        }
        else if (attempt.IsHardCapReached())
        {
            sb.AppendLine("## The conversation has reached its maximum length.");
            sb.AppendLine("Provide a brief closing summary. Do not ask more questions.");
        }
        else
        {
            var uncoveredKpIds = task.GetUncoveredPropositionIds(attempt);
            var unarticulatedKrIds = task.GetUnarticulatedRelationIds(attempt);
            if (uncoveredKpIds.Any() || unarticulatedKrIds.Any())
            {
                sb.AppendLine("## Focus areas for the next question:");
                if (uncoveredKpIds.Any())
                    sb.AppendLine($"- Uncovered key propositions: {string.Join(", ", uncoveredKpIds.Select(id => $"KP-{id}"))}");
                if (unarticulatedKrIds.Any())
                    sb.AppendLine($"- Unarticulated key relations: {string.Join(", ", unarticulatedKrIds.Select(id => $"KR-{id}"))}");
                sb.AppendLine("Pick the most important gap and probe it. Never reveal the underlying statement or mechanism text.");
                sb.AppendLine();
            }

            if (attempt.IsSoftCapReached())
            {
                sb.AppendLine("## The learner is approaching the end of the conversation.");
                sb.AppendLine("Suggest wrapping up. Focus on the most important uncovered gap above.");
            }
        }
        return sb.ToString();
    }

    public static List<(string role, string content)> BuildMessages(List<ConversationTurn> history)
    {
        var messages = new List<(string role, string content)>();
        foreach (var turn in history)
        {
            var role = turn.Role == TurnRole.Learner ? "user" : "assistant";
            messages.Add((role, turn.Content));
        }
        return messages;
    }
}
