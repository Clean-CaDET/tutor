namespace Tutor.LanguageModelConversations.API.Dtos;
public class ConversationMessageDto
{
    public string Sender { get; set; }
    // bitno za FE: serijalizovan dto objekat ili cist string ako je human poruka
    public string Content { get; set; }
}
