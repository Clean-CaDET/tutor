using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IAgentOrchestrator
{
    IAsyncEnumerable<OrchestratorChunk> ProcessTurnAsync(ConversationAttempt attempt,
        ConceptRecord record, string newMessage, CancellationToken ct);
}
