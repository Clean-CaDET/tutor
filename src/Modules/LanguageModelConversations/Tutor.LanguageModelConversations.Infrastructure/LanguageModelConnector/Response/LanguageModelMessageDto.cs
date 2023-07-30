using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

public class LanguageModelMessageDto
{
    public LanguageModelMessageDataDto Data { get; set; }
    public SenderType Type { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SenderType
{
    System,
    Human,
    Ai
}
