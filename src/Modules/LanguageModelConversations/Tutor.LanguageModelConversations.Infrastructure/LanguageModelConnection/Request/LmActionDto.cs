using Tutor.LanguageModelConversations.API.Dtos;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Request;

public class LmActionDto
{
    public string Text { get; set; }
    public ContextType Context { get; set; }
}
