namespace Tutor.BuildingBlocks.AI.Core.Conversations;

/// <summary>
/// Accumulates <see cref="TokenUsage"/> across every LLM call within one scope (typically one HTTP request / one conversation turn).
/// Implementations must be thread-safe.
/// </summary>
public interface ITurnUsageTracker
{
    void Add(TokenUsage usage);

    TokenUsage Total { get; }
}
