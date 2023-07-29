using Tutor.LanguageModelConversations.API.Dtos;

namespace Tutor.LanguageModelConversations.Infrastructure.Http.Dtos;

public class LmActionRequest
{
    public string Text { get; set; }
    public ContextType Context { get; set; }
}
