namespace Tutor.Elaborations.Core.Domain.Conversations;

public record FeedbackTarget(ScoredTarget ScoredTarget, int ProbesWithoutGradeChangeCount)
{
    public bool IsStalled() => ProbesWithoutGradeChangeCount >= 2;
};
