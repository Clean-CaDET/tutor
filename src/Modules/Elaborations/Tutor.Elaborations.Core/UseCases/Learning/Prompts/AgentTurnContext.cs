using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public sealed record AgentTurnContext(
    string? Target = null,
    int? Level = null,
    TurnEvaluation? Evaluation = null,
    string? CurrentLearnerMessage = null);
