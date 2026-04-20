using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IEvaluationAgent
{
    Task<Result<TurnAnalysis>> AnalyzeAsync(string content,
        List<ConversationTurn> history, ConceptElaborationTask task,
        CancellationToken ct);
}
