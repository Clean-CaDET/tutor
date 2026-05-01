using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IAgentOrchestrator
{
    IAsyncEnumerable<OrchestratorChunk> ProcessTurnAsync(
        ConceptRecord record, ConversationAttempt attempt, string newMessage, CancellationToken ct);
}
