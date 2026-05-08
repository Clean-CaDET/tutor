namespace Tutor.Elaborations.Core.Domain.Conversations;

public record ScoredTarget(string Key, TargetType Type, int Grade, string Evidence = "")
{
    public bool SameTarget(ScoredTarget other) => Key == other.Key && Type == other.Type;
    public int SeverityRank() => Grade switch { -2 => 0, -1 => 1, 1 => 2, _ => 3 };
}