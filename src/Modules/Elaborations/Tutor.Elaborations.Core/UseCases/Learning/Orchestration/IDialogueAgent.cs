using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public interface IDialogueAgent
{
    IAsyncEnumerable<string> StreamAsync(TurnEvaluation evaluation,
        List<ConversationTurn> history, ConceptRecord conceptRecord,
        ConversationState state, CancellationToken ct);
}
