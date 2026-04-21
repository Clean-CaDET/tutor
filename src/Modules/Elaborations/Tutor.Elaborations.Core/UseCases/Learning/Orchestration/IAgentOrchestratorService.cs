using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IAgentOrchestratorService
{
    IAsyncEnumerable<OrchestratorChunk> ProcessTurnAsync(
        ConversationAttempt attempt, ConceptElaborationTask task,
        string learnerContent, CancellationToken ct);
}
