using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

/// <summary>
/// Per-turn volatile state handed to an agent. Lives in the trailing user message
/// (rendered by <see cref="RuntimeContextBlock"/>) so none of it pollutes the cacheable system prompt.
/// Every field is optional; agents populate only what they need.
/// </summary>
public sealed record AgentTurnContext(
    string Instruction,
    string? ProgressLine = null,
    string? Target = null,
    bool SoftCapReached = false,
    TurnEvaluation? Evaluation = null,
    string? CurrentLearnerMessage = null);
