using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface ISummaryAgent
{
    Task<Result<string>> SummarizeAsync(ConversationAttempt attempt,
        ConceptRecord conceptRecord, CancellationToken ct);
}
