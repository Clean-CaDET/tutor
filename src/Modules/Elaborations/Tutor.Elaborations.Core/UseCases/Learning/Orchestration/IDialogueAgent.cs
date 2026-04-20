using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IDialogueAgent
{
    IAsyncEnumerable<string> StreamAsync(TurnAnalysis analysis,
        ConversationAttempt attempt, ConceptElaborationTask task,
        CancellationToken ct);
}
