using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IAgentStream
{
    IAsyncEnumerable<StreamOutput> StreamAsync(
        AgentKind kind, IReadOnlyList<ConversationTurn> history,
        ConceptRecord record, AgentTurnContext ctx, CancellationToken ct);
}
