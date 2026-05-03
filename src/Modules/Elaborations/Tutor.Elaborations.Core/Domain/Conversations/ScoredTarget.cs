namespace Tutor.Elaborations.Core.Domain.Conversations;

public record ScoredTarget(string Key, ScoredTargetType Type, int Grade);

public enum ScoredTargetType { Proposition, Relation }
