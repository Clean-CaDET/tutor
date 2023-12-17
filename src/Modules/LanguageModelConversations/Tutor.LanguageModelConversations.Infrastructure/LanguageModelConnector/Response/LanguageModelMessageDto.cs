using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

public class LanguageModelMessageDto
{
    public LanguageModelMessageDataDto Data { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LanguageModelSenderType Type { get; set; }
}

public enum LanguageModelSenderType
{
    System,
    Human,
    Ai
}
