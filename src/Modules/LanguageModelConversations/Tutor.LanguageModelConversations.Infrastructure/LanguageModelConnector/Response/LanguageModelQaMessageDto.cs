using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

internal class LanguageModelQaMessageDto
{
    [JsonPropertyName("pitanje")]
    public string Question { get; set; }

    [JsonPropertyName("odgovor")]
    public string Answer { get; set; }
}
