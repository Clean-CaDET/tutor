namespace Tutor.LanguageModelConversations.API.Dtos;

// TODO: imenovanje -> izbacili smo request i response, smisliti kako ce se drugacije zvati ili staviti u request/response foldere
public class MessageRequest
{
    public int ConversationId { get; set; }
    public int CourseId { get; set; }
    public int ContextId { get; set; }
    public string MessageType { get; set; }
    public int? TaskId { get; set; }
    public string? Message { get; set; }
}
