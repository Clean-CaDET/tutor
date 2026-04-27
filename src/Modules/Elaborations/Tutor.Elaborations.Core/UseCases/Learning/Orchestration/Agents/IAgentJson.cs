using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IAgentJson
{
    Task<Result<TResponse>> CompleteAsync<TResponse>(
        IReadOnlyList<ConversationTurn> history, ConceptRecord record, AgentTurnContext ctx,
        CancellationToken ct) where TResponse : class;
}
