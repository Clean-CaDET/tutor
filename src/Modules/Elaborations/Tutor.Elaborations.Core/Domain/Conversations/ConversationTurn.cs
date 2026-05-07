using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationTurn : Entity
{
    public int ConversationAttemptId { get; private set; }
    public TurnRole Role { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public int Order { get; private set; }
    public DateTime Timestamp { get; private set; }
    public TurnEvaluation? Evaluation { get; private set; }

    public IReadOnlyList<FeedbackTarget> FeedbackTargets { get; private set; } = [];

    private ConversationTurn() { }

    internal ConversationTurn(string content, int order, TurnEvaluation? evaluation)
    {
        Role = TurnRole.Learner;
        Timestamp = DateTime.UtcNow;
        Content = content;
        Order = order;
        Evaluation = evaluation;
        FeedbackTargets = [];
    }

    internal ConversationTurn(string content, int order, IReadOnlyList<FeedbackTarget> feedbackTargets)
    {
        Role = TurnRole.System;
        Timestamp = DateTime.UtcNow;
        Content = content;
        Order = order;
        FeedbackTargets = feedbackTargets;
    }
}
