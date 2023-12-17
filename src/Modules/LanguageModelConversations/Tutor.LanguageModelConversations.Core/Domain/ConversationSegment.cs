namespace Tutor.LanguageModelConversations.Core.Domain;

public class ConversationSegment
{
    public List<LanguageModelMessage> Messages { get; private set; }
    public int TokensUsed { get; private set; }

    private ConversationSegment() {}

    public ConversationSegment(List<LanguageModelMessage> messages, int tokensUsed)
    {
        Messages = messages;
        TokensUsed = tokensUsed;
    }
}
