using Tutor.LanguageModelConversations.API.Dtos.Integration.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.Http.Dtos;

public class LmOpenEndedLectureRequest
{
    public string NewMessage { get; set; }
    public string LectureText { get; set; }
    public List<LmMessageDto>? PreviousMessages { get; set; }
}
