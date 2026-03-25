using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public record EvaluationResult(TurnEvaluation Evaluation, bool IsSubstantive);
