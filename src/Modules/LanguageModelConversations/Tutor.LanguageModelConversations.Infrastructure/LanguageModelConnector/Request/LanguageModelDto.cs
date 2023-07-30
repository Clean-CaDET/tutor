using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Request;

// TODO: da li ovo moze da bude internal klasa?
internal class LanguageModelDto
{
    public string Text { get; set; }
    public ContextType? Context { get; set; }
    public string? Message { get; set; }
    public List<LanguageModelMessageDto>? PreviousMessages { get; set; } 
}
