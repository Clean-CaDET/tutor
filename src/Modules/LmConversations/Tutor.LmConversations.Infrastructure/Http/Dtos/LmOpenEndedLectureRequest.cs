using Tutor.LmConversations.API.Dtos.Integration.Response;

namespace Tutor.LmConversations.Infrastructure.Http.Dtos;

public class LmOpenEndedLectureRequest
{
    public string NewMessage { get; set; }
    public string LectureText { get; set; }
    public List<LmMessageDto>? PreviousMessages { get; set; }
}
