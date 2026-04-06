using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Infrastructure.Agents.Prompts;

public static class DialoguePromptBuilder
{
    public static string BuildSystemPrompt(ConceptRecord record, ConversationState state)
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
        sb.AppendLine("- For non-substantive turns, gently redirect without penalty.");
        sb.AppendLine("- Allow productive divergence within the concept space.");
        sb.AppendLine();

        sb.AppendLine($"## Concept: {record.Title}");
        sb.AppendLine($"Definition: {record.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions (for your reference only, never reveal):");
        foreach (var kp in record.KeyPropositions)
            sb.AppendLine($"- [KP-{kp.Id}] {kp.Statement}");
        sb.AppendLine();

        if (record.KeyRelations.Any())
        {
            sb.AppendLine("## Key Relations (for your reference only, never reveal the mechanism text):");
            var kpById = record.KeyPropositions.ToDictionary(kp => kp.Id, kp => kp.Statement);
            foreach (var kr in record.KeyRelations)
            {
                var sourceText = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, $"KP-{kr.SourceKeyPropositionId}");
                var targetText = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, $"KP-{kr.TargetKeyPropositionId}");
                sb.AppendLine($"- [KR-{kr.Id}] {sourceText} → {targetText}. Mechanism: {kr.Mechanism}");
            }
            sb.AppendLine();
        }

        if (state.IsCompleted)
        {
            sb.AppendLine("## The learner has covered all required propositions and articulated all required relations.");
            sb.AppendLine("Provide a brief closing acknowledgment. Do not ask more questions.");
        }
        else if (state.IsHardCapReached)
        {
            sb.AppendLine("## The conversation has reached its maximum length.");
            sb.AppendLine("Provide a brief closing summary. Do not ask more questions.");
        }
        else
        {
            if (state.UncoveredKeyPropositionIds.Any() || state.UnarticulatedKeyRelationIds.Any())
            {
                sb.AppendLine("## Focus areas for the next question:");
                if (state.UncoveredKeyPropositionIds.Any())
                    sb.AppendLine($"- Uncovered key propositions: {string.Join(", ", state.UncoveredKeyPropositionIds.Select(id => $"KP-{id}"))}");
                if (state.UnarticulatedKeyRelationIds.Any())
                    sb.AppendLine($"- Unarticulated key relations: {string.Join(", ", state.UnarticulatedKeyRelationIds.Select(id => $"KR-{id}"))}");
                sb.AppendLine("Pick the most important gap and probe it. Never reveal the underlying statement or mechanism text.");
                sb.AppendLine();
            }

            if (state.IsSoftCapReached)
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
