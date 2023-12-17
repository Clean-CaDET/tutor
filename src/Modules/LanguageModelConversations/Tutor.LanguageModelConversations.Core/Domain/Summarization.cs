using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class Summarization : Entity
{
    public int ContextId { get; private set; }
    public ContextGroup Group { get; private set; }
    public List<LanguageModelMessage> Messages { get; private set; }

    private Summarization() {}
    public Summarization(int contextId, ContextGroup group, List<LanguageModelMessage> messages)
    {
        ContextId = contextId;
        Group = group;
        Messages = messages;
    }
}
