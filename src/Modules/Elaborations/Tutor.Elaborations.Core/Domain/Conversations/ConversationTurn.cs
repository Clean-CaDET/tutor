using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationTurn : Entity
{
    public int ConversationAttemptId { get; private set; }
    public TurnRole Role { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public int Order { get; private set; }
    public DateTime Timestamp { get; private set; }
    public TurnIntent? Intent { get; private set; }
    public TurnEvaluation? Evaluation { get; private set; }
    public string? ProbeTarget { get; private set; }
    public int? ProbeLevel { get; private set; }

    private ConversationTurn() { }

    internal ConversationTurn(
        TurnRole role, string content, int order,
        TurnIntent? intent = null, TurnEvaluation? evaluation = null,
        ProbeDirective? probeDirective = null)
    {
        Role = role;
        Content = content;
        Order = order;
        Timestamp = DateTime.UtcNow;
        Intent = intent;
        Evaluation = evaluation;
        ProbeTarget = probeDirective?.Target;
        ProbeLevel = probeDirective?.Level;
    }
}
