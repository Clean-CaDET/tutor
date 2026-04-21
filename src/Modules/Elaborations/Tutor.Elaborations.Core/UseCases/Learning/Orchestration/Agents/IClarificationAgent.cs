using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IClarificationAgent
{
    IAsyncEnumerable<string> StreamAsync(
        ConversationAttempt attempt, ConceptElaborationTask task,
        ProbeDirective? lastProbe, CancellationToken ct);
}
