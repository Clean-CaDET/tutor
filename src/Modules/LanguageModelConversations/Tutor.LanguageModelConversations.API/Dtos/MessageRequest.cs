namespace Tutor.LanguageModelConversations.API.Dtos;

public class MessageRequest
{
    public int ConversationId { get; set; }
    public int ContextId { get; set; }
    public MessageType Type { get; set; }
    public int? TaskId { get; set; }
    public string? Message { get; set; }
}

public enum MessageType
{
    OpenEnded,
    Summarize,
    Keywords,
    LectureQuestions,
    SimilarTask
}
