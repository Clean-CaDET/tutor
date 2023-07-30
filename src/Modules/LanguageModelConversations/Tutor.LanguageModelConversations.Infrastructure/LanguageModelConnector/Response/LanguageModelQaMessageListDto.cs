using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

internal class LanguageModelQaMessageListDto
{
    [JsonPropertyName("lista")]
    public List<LanguageModelQaMessageDto> Messages { get; set; }
}
