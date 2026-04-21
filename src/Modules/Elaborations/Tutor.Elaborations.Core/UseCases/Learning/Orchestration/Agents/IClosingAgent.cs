using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public enum ClosingReason { AllCovered, HardCapReached }

public interface IClosingAgent
{
    IAsyncEnumerable<string> StreamAsync(
        ConceptElaborationTask task, ClosingReason reason, CancellationToken ct);
}
