using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class Conversation : Entity
{
    public int LearnerId { get; private set; }
    public ContextGroup Group { get; private set; }
    public int ContextId { get; private set; }
    public List<LanguageModelMessage> Messages { get; private set; }

    private Conversation() {}
    public Conversation(int id, int learnerId, ContextGroup group, int contextId)
    {
        Id = id;
        LearnerId = learnerId;
        Group = group;
        ContextId = contextId;
        Messages = new List<LanguageModelMessage>();
    }

    public void AddMessages(List<LanguageModelMessage> messages)
    {
        Messages.AddRange(messages);
    }
}

public enum ContextGroup
{
    KnowledgeComponent,
    LearningTask
}
