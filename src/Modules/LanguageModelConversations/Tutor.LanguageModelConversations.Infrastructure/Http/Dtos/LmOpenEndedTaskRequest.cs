using Tutor.LanguageModelConversations.API.Dtos.Integration.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.Http.Dtos;

public class LmOpenEndedTaskRequest
{
    public string NewMessage { get; set; }
    public string TaskText { get; set; }
    public List<LmMessageDto>? PreviousMessages { get; set; }
}
