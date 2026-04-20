using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public record TurnAnalysis(TurnIntent Intent, TurnEvaluation? Evaluation, bool HasMultipleConcerns = false)
{
    public static TurnAnalysis Substantive(TurnEvaluation evaluation, bool hasMultipleConcerns) =>
        new(TurnIntent.Substantive, evaluation, hasMultipleConcerns);
    public static TurnAnalysis Clarification() => new(TurnIntent.Clarification, null);
    public static TurnAnalysis OffTopic() => new(TurnIntent.OffTopic, null);
}
