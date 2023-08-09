namespace Tutor.LanguageModelConversations.API.Dtos;

public class ConversationDto
{
    public int Id { get; set; }
    public int LearnerId { get; set; }
    public int ContextId { get; set; }
    public List<ConversationMessageDto> Messages { get; set; }
}
