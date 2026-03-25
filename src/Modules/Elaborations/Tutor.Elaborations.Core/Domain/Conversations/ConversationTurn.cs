using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationTurn : Entity
{
    public int ConversationAttemptId { get; private set; }
    public TurnRole Role { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public bool IsSubstantive { get; private set; }
    public int Order { get; private set; }
    public DateTime Timestamp { get; private set; }
    public TurnEvaluation? Evaluation { get; private set; }

    private ConversationTurn() { }

    internal ConversationTurn(TurnRole role, string content,
        bool isSubstantive, int order, TurnEvaluation? evaluation = null)
    {
        Role = role;
        Content = content;
        IsSubstantive = isSubstantive;
        Order = order;
        Timestamp = DateTime.UtcNow;
        Evaluation = evaluation;
    }
}
