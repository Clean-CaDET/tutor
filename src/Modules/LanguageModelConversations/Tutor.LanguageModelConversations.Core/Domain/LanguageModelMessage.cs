namespace Tutor.LanguageModelConversations.Core.Domain;

public class LanguageModelMessage
{
    public string Content { get; private set; }
    public SenderType SenderType { get; private set; }
    public MessageType MessageType { get; set; }

    private LanguageModelMessage() {}
    public LanguageModelMessage(string content, SenderType senderType)
    {
        Content = content;
        SenderType = senderType;
        MessageType = MessageType.TopicConversation;
    }
}

public enum SenderType
{
    System,
    Learner,
    LanguageModel
}

public enum MessageType
{
    TopicConversation,
    GenerateSimilar,
    Summarize,
    ExtractKeywords,
    GenerateQuestions
}
