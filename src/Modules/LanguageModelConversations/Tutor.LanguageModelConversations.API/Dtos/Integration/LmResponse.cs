using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.API.Dtos.Integration.Response;

public class LmResponse
{
    public List<LmMessageDto> Messages { get; set; }
    [JsonPropertyName("numOfTokens")]
    public decimal TokenNumber { get; set; }
}

public class LmMessageDto
{
    public LmMessageDataDto Data { get; set; }
    public string Type { get; set; }
}

public class LmMessageDataDto
{
    public string Content { get; set; }
}
