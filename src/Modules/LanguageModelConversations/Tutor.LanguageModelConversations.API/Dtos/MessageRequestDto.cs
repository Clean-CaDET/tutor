namespace Tutor.LanguageModelConversations.API.Dtos;

public class MessageRequestDto
{
    public int ConversationId { get; set; }
    public int CourseId { get; set; }
    public int ContextGroup { get; set; }
    public int ContextId { get; set; }
    public string MessageType { get; set; }
    public int? TaskId { get; set; }
    public string? Message { get; set; }
}
