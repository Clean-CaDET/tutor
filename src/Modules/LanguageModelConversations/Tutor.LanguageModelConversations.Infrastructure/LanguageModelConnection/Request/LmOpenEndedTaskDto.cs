using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Request;

public class LmOpenEndedTaskDto
{
    public string NewMessage { get; set; }
    public string TaskText { get; set; }
    public List<LmMessageDto>? PreviousMessages { get; set; }
}
