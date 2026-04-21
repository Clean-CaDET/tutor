using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface ICritiqueAgent
{
    IAsyncEnumerable<string> StreamAsync(
        TurnEvaluation evaluation, ConversationAttempt attempt,
        ConceptElaborationTask task, CancellationToken ct);
}
