using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Domain;

public class Conversation : Entity
{
    public int LearnerId { get; private set; }
    // ContextType -> koji modul pozivati za ucitavanje konteksta
    public int ContextId { get; private set; }
    public List<LanguageModelMessage> Messages { get; private set; }

    public Conversation(int id, int learnerId, int contextId)
    {
        Id = id;
        LearnerId = learnerId;
        ContextId = contextId;
        Messages = new List<LanguageModelMessage>();
    }

    public void AddMessages(List<LanguageModelMessage> messages)
    {
        Messages.AddRange(messages);
    }
}
