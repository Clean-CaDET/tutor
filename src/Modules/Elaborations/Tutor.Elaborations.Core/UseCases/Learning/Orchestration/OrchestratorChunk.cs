using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public abstract record OrchestratorChunk;

public sealed record TokenChunk(string Token) : OrchestratorChunk;

public sealed record FinalChunk(
    int AttemptId,
    AttemptStatus Status,
    TurnIntent Intent,
    string? Summary,
    TokenUsage Usage) : OrchestratorChunk;

public sealed record ErrorChunk(string Message, int Code) : OrchestratorChunk;
