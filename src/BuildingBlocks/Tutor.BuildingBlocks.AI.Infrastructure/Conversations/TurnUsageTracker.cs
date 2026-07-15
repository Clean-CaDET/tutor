using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Conversations;

public sealed class TurnUsageTracker : ITurnUsageTracker
{
    private readonly object _lock = new();
    private int _promptTokens;
    private int _completionTokens;

    public void Add(TokenUsage usage)
    {
        lock (_lock)
        {
            _promptTokens += usage.PromptTokens;
            _completionTokens += usage.CompletionTokens;
        }
    }

    public TokenUsage Total
    {
        get
        {
            lock (_lock)
            {
                return new TokenUsage(_promptTokens, _completionTokens);
            }
        }
    }
}
