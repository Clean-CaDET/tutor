using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IEvaluationAgent
{
    Task<Result<EvaluationResult>> EvaluateAsync(string content,
        List<ConversationTurn> history, ConceptRecord conceptRecord,
        CancellationToken ct);
}
