using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IRedirectAgent
{
    IAsyncEnumerable<string> StreamAsync(ConceptElaborationTask task, CancellationToken ct);
}
