using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public record TurnAnalysis(TurnIntent Intent, TurnEvaluation? Evaluation)
{
    public static TurnAnalysis Substantive(TurnEvaluation evaluation) => new(TurnIntent.Substantive, evaluation);
    public static TurnAnalysis Clarification() => new(TurnIntent.Clarification, null);
    public static TurnAnalysis OffTopic() => new(TurnIntent.OffTopic, null);
}
