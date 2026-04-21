using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface ISummaryAgent
{
    Task<Result<string>> SummarizeAsync(ConversationAttempt attempt,
        ConceptElaborationTask task, CancellationToken ct);
}
