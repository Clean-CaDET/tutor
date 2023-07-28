using Tutor.LmConversations.API.Dtos;

namespace Tutor.LmConversations.Infrastructure.Http.Dtos;

public class LmActionRequest
{
    public string Text { get; set; }
    public ContextType Context { get; set; }
}
