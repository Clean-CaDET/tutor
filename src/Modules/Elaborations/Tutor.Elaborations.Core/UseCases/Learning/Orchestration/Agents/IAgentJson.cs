using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IAgentJson
{
    Task<Result<TResult>> CompleteAsync<TResponse, TResult>(
        AgentKind kind, IReadOnlyList<ConversationTurn> history,
        ConceptRecord record, AgentTurnContext ctx,
        Func<TResponse, Result<TResult>> validateAndMap,
        string failureMessage, CancellationToken ct) where TResponse : class;
}
