using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IMetaHelpAgent
{
    IAsyncEnumerable<StreamOutput> StreamAsync(
        ConceptElaborationTask task, string progressLine,
        ProbeDirective? nextTarget, CancellationToken ct);
}
