using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationRound : Entity
{
    public int ConversationAttemptId { get; private set; }
    public int Order { get; private set; }
    public string ElaborationContent { get; private set; } = string.Empty;
    public DateTime SubmittedAt { get; private set; }
    public TurnEvaluation Evaluation { get; private set; } = null!;
    public string? FeedbackContent { get; private set; }
    public IReadOnlyList<FeedbackTarget> FeedbackTargets { get; private set; } = [];

    private ConversationRound() { }

    internal ConversationRound(int order, string elaborationContent, TurnEvaluation evaluation)
    {
        Order = order;
        ElaborationContent = elaborationContent;
        SubmittedAt = DateTime.UtcNow;
        Evaluation = evaluation;
    }

    internal void Complete(string feedbackContent, IReadOnlyList<FeedbackTarget> feedbackTargets)
    {
        FeedbackContent = feedbackContent;
        FeedbackTargets = feedbackTargets;
    }
}
