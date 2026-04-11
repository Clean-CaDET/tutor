using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IEvaluationAgent
{
    Task<Result<EvaluationResult>> EvaluateAsync(string content,
        List<ConversationTurn> history, ConceptElaborationTask task,
        CancellationToken ct);
}
