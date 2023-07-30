namespace Tutor.LanguageModelConversations.Core.Domain;

public class LanguageModelMessage
{
    // DONE: json serijalizovan u string ili string
    public string Content { get; set; }
    public SenderType SenderType { get; set; }
    public MessageType MessageType { get; set; }
    public int TokensUsed { get; set; }
}
// na dva mesta ista enumeracija -> u api projektu i ovde, da li je bitno itno itno??? ???
public enum SenderType
{
    Learner,
    LanguageModel
}

public enum MessageType
{
    OpenEnded,
    Predefined
}
