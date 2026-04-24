using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

/// <summary>
/// Maps domain <see cref="ConversationTurn"/>s to native-role <see cref="ChatMessage"/>s
/// so the provider can cache against alternating user/assistant turns instead of a flattened transcript.
/// </summary>
public static class ConversationHistoryMapper
{
    public static List<ChatMessage> Map(IEnumerable<ConversationTurn> turns, int? lastN = null)
    {
        var ordered = turns.OrderBy(t => t.Order);
        var window = lastN is { } n ? ordered.TakeLast(n) : ordered;
        return window.Select(t => t.Role == TurnRole.Learner
            ? ChatMessage.FromUser(t.Content)
            : ChatMessage.FromAssistant(t.Content)).ToList();
    }
}
