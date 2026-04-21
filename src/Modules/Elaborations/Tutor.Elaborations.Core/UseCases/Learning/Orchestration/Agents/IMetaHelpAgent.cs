using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IMetaHelpAgent
{
    IAsyncEnumerable<string> StreamAsync(
        ConceptElaborationTask task, string progressLine,
        ProbeDirective? nextTarget, CancellationToken ct);
}
