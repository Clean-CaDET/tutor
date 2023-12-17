using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

public class LanguageModelDto
{
    public List<LanguageModelMessageDto> Messages { get; set; }
    [JsonPropertyName("numOfTokens")]
    public int TokensUsed { get; set; }
}
