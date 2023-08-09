using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class Conversation : Entity
{
    public int LearnerId { get; private set; }
    public ContextGroup ContextGroup { get; private set; }
    public int ContextId { get; private set; }
    public List<LanguageModelMessage> Messages { get; private set; }

    private Conversation() {}
    public Conversation(int id, int learnerId, ContextGroup contextGroup, int contextId)
    {
        Id = id;
        LearnerId = learnerId;
        ContextGroup = contextGroup;
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
