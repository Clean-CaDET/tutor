using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IProbeAgent
{
    IAsyncEnumerable<string> StreamAsync(
        ProbeDirective directive, ConversationAttempt attempt,
        ConceptElaborationTask task, CancellationToken ct);
}
