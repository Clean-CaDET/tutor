using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IScorer
{
    Task<Result<TurnEvaluation>> ScoreAsync(
        string content, List<ConversationTurn> history,
        ConceptElaborationTask task, CancellationToken ct);
}
