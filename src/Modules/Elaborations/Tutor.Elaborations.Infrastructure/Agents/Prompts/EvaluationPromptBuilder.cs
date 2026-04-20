using System.Text;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Agents.Prompts;

public static class EvaluationPromptBuilder
{
    public static string BuildSystemPrompt(ConceptElaborationTask task)
    {
        var hasBoundaryConditions = task.BoundaryConditions.Count != 0;
        var hasCommonMisconceptions = task.CommonMisconceptions.Count != 0;
        var hasKeyRelations = task.KeyRelations.Count != 0;

        var sb = new StringBuilder();
        sb.AppendLine("You are an evaluation agent for a Socratic tutoring system.");
        sb.AppendLine("Your task: classify the learner's latest message, then (only if Substantive) score it against the concept rubric. Output JSON. DO NOT OUTPUT ANYTHING ELSE.");
        sb.AppendLine();
        sb.AppendLine($"## Concept: {task.Title}");
        sb.AppendLine($"Definition: {task.CanonicalDefinition}");
        sb.AppendLine();

        sb.AppendLine("## Key Propositions:");
        foreach (var kp in task.KeyPropositions)
            sb.AppendLine($"ID={kp.Id} {kp.Statement}");
        sb.AppendLine();

        if (hasBoundaryConditions)
        {
            sb.AppendLine("## Boundary Conditions:");
            foreach (var bc in task.BoundaryConditions)
                sb.AppendLine($"ID={bc.Id} {bc.Statement}");
            sb.AppendLine();
        }

        if (hasCommonMisconceptions)
        {
            sb.AppendLine("## Common Misconceptions:");
            foreach (var cm in task.CommonMisconceptions.Take(8))
                sb.AppendLine($"ID={cm.Id} {cm.Description} → Correction: {cm.Correction}");
            sb.AppendLine();
        }

        if (hasKeyRelations)
        {
            sb.AppendLine("## Key Relations:");
            var kpById = task.KeyPropositions.ToDictionary(kp => kp.Id, kp => kp.Statement);
            foreach (var kr in task.KeyRelations)
            {
                var sourceText = kpById.GetValueOrDefault(kr.SourceKeyPropositionId, $"KP-{kr.SourceKeyPropositionId}");
                var targetText = kpById.GetValueOrDefault(kr.TargetKeyPropositionId, $"KP-{kr.TargetKeyPropositionId}");
                sb.AppendLine($"ID={kr.Id} {sourceText} → {targetText}. Mechanism: {kr.Mechanism}");
            }
            sb.AppendLine();
        }

        sb.AppendLine(CreateIntentRules());
        sb.AppendLine(CreateScoringRules(hasBoundaryConditions, hasKeyRelations, hasCommonMisconceptions));

        return sb.ToString();
    }

    private static string CreateIntentRules()
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Intent Classification (decide first):");
        sb.AppendLine("- Substantive: the learner attempts to explain, define, relate, or apply the concept. Even a weak or partial attempt counts.");
        sb.AppendLine("- Clarification: the learner asks a genuine information-seeking question about the task, the concept, or a previous tutor message. Must be a direct question (what / why / how / can you give an example / what do you mean by ...?). A message is Clarification ONLY if removing the rest and keeping just the question still makes sense.");
        sb.AppendLine("- OffTopic: everything else. This includes small talk, jokes, personal questions, refusals or disengagement (\"I don't want to\", \"I'm not in the mood\", \"this is boring\", \"can we do something else\"), meta-comments about the conversation, and any message that is neither a concept explanation nor an information-seeking question. When in doubt between Clarification and OffTopic, choose OffTopic.");
        sb.AppendLine();
        sb.AppendLine("## Echo rule (apply before scoring)");
        sb.AppendLine("If the message to score is a verbatim or near-verbatim repetition of any [TUTOR] line in the conversation so far, classify intent as OffTopic. Credit for a Key Proposition or Key Relation requires the learner to articulate it in their own words, not repeat the tutor.");
        sb.AppendLine();
        sb.AppendLine("## Scope rule");
        sb.AppendLine("Score only the message demarcated as '## Message to score'. Do not attribute content from [TUTOR] lines to the learner. If the learner's message expresses agreement with, approval of, or deference to something the tutor said (e.g. 'I bet you'd explain it well', 'that's right', 'you said it'), that is not articulation of the concept — classify as OffTopic.");
        return sb.ToString();
    }

    private static string CreateScoringRules(bool hasBoundaryConditions, bool hasKeyRelations, bool hasCommonMisconceptions)
    {
        var sb = new StringBuilder();
        sb.AppendLine("## Scoring Rules (apply only when intent is Substantive):");
        var correctnessLine = hasBoundaryConditions
            ? "- Correctness (1-3): Are stated claims true? Check against KPs and BCs."
            : "- Correctness (1-3): Are stated claims true? Check against KPs.";
        sb.AppendLine(correctnessLine);
        sb.AppendLine("- Completeness (1-3): Are essential KPs covered?");
        if (hasBoundaryConditions)
            sb.AppendLine("- Discrimination (1-3): Does the explanation correctly exclude non-examples? Check BCs.");
        if (hasKeyRelations)
            sb.AppendLine("- Integration (1-3): Did the learner articulate the key relations *with mechanism*? Score 1 if no relation articulated, 2 if relations mentioned without mechanism, 3 if relations articulated with explicit mechanism matching the authored description.");
        sb.AppendLine("- Evaluate concepts, not language. Grammar and style must not reduce scores.");
        sb.AppendLine("- Resist sycophancy. Evaluate strictly against rubric.");
        sb.AppendLine();
        sb.AppendLine("## Concern count (used to route the dialogue agent):");
        sb.AppendLine("Count distinct concerns in the message. A concern is any of:");
        sb.AppendLine("  - a stated inaccuracy (a claim that contradicts a KP or BC);");
        if (hasCommonMisconceptions)
            sb.AppendLine("  - a triggered known misconception or a novel misconception;");
        else
            sb.AppendLine("  - a novel misconception (none are pre-catalogued for this concept);");
        sb.AppendLine("  - a vague or hand-wavy claim that references a KP without articulating it.");
        sb.AppendLine("Output hasMultipleConcerns=true if the count is two or more; false otherwise. A clean or single-concern answer is false.");
        sb.AppendLine();

        sb.AppendLine("## Output Format (JSON only, no other text):");
        sb.AppendLine("If intent is Clarification or OffTopic, output exactly:");
        sb.AppendLine("{ \"intent\": \"Clarification\" }  // or \"OffTopic\"");
        sb.AppendLine();
        sb.AppendLine("If intent is Substantive, output:");
        var fields = new List<string>
        {
            "\"intent\": \"Substantive\"",
            "\"correctnessScore\": 1-3",
            "\"completenessScore\": 1-3"
        };
        if (hasBoundaryConditions) fields.Add("\"discriminationScore\": 1-3");
        if (hasKeyRelations) fields.Add("\"integrationScore\": 1-3");
        fields.Add("\"justification\": \"brief explanation of scores\"");
        fields.Add("\"propositionsCoveredIds\": [number list of KP IDs covered in this turn]");
        if (hasCommonMisconceptions) fields.Add("\"misconceptionsTriggeredIds\": [number list of CM IDs triggered]");
        if (hasKeyRelations) fields.Add("\"relationsArticulatedIds\": [number list of KR IDs articulated with mechanism this turn]");
        if (hasCommonMisconceptions) fields.Add("\"novelMisconceptions\": \"any misconceptions not in the list, or null\"");
        fields.Add("\"hasMultipleConcerns\": true|false");

        sb.AppendLine("{");
        sb.AppendLine(string.Join(",\n", fields.Select(f => "  " + f)));
        sb.AppendLine("}");
        return sb.ToString();
    }

    public static string BuildUserMessage(
        string learnerContent, List<ConversationTurn> history)
    {
        var sb = new StringBuilder();

        sb.AppendLine("## Conversation so far (for context only — DO NOT score this)");
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

        sb.AppendLine("## Message to score (this is the ONLY message you are scoring)");
        sb.AppendLine($"[LEARNER]: {learnerContent}");
        sb.AppendLine();

        sb.AppendLine("Score only the final [LEARNER] message under '## Message to score'. Do not credit the learner for content that appears in [TUTOR] lines or that the learner has only repeated from a preceding [TUTOR] line.");

        return sb.ToString();
    }
}
