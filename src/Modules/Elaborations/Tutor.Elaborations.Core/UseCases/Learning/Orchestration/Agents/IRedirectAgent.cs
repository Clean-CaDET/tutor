using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IRedirectAgent
{
    IAsyncEnumerable<StreamOutput> StreamAsync(ConceptElaborationTask task, CancellationToken ct);
}
