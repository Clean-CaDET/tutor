using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Request;

public class LmOpenEndedLectureDto
{
    public string NewMessage { get; set; }
    public string LectureText { get; set; }
    public List<LmMessageDto>? PreviousMessages { get; set; }
}
