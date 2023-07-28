using Tutor.LmConversations.API.Dtos.Integration.Response;

namespace Tutor.LmConversations.Infrastructure.Http.Dtos;

public class LmOpenEndedTaskRequest
{
    public string NewMessage { get; set; }
    public string TaskText { get; set; }
    public List<LmMessageDto>? PreviousMessages { get; set; }
}
