using System.Text.Json.Serialization;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Request;

// da li koristimo internal klase?
internal class LanguageModelDto
{
    public string Text { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ContextType? Context { get; set; }
    public string? Message { get; set; }
    public List<LanguageModelMessageDto>? PreviousMessages { get; set; } 
}
