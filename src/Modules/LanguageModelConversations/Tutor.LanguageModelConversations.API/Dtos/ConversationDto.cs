namespace Tutor.LanguageModelConversations.API.Dtos;

public class ConversationDto
{
    public int Id { get; set; }
    public int LearnerId { get; set; }
    public int ContextId { get; set; }
    public List<ConversationMessageDto> Messages { get; set; }
}

public class ConversationMessageDto
{
    public SenderType Sender { get; set; }
    // serijalizovan lmMessageDto ili cist string ako je human poruka
    public string Message { get; set; }
}

public enum SenderType
{
    Learner,
    LanguageModel
}
