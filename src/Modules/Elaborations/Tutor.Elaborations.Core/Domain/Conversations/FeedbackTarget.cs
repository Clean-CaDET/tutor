namespace Tutor.Elaborations.Core.Domain.Conversations;

public record FeedbackTarget(string Key, TargetType Type, int Grade, bool NeedsSupport);
