using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IDialogueAgent
{
    IAsyncEnumerable<string> StreamAsync(TurnEvaluation evaluation,
        List<ConversationTurn> history, ConceptElaborationTask task,
        ConversationState state, CancellationToken ct);
}
