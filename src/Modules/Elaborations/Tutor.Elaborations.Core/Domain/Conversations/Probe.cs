namespace Tutor.Elaborations.Core.Domain.Conversations;

public record Probe(ScoredTarget ScoredTarget, int StagnantCount)
{
    public bool IsStalled() => StagnantCount >= 2;
}