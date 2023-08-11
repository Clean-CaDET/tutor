namespace Tutor.LanguageModelConversations.API.Dtos;
public class ConversationMessageDto
{
    public string Sender { get; set; }
    // Content is serialized JSON or plain string
    public string Content { get; set; }
}
