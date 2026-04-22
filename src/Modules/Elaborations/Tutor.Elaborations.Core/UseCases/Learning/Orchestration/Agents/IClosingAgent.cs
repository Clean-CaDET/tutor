using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public enum ClosingReason { AllCovered, HardCapReached }

public interface IClosingAgent
{
    IAsyncEnumerable<StreamOutput> StreamAsync(
        ConceptElaborationTask task, ClosingReason reason, CancellationToken ct);
}
