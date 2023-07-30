using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Response;

internal class LanguageModelKeywordMessageDto
{
    [JsonPropertyName("kljucna_rec")]
    public string Keyword { get; set; }

    [JsonPropertyName("objasnjenje")]
    public string Explanation { get; set; }
}
