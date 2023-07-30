using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

internal class LanguageModelKeywordMessageListDto
{
    [JsonPropertyName("lista")]
    public List<LanguageModelKeywordMessageDto> Messages { get; set; }
}
