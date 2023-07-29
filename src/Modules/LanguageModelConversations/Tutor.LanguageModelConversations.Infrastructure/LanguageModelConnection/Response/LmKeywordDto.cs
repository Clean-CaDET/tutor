using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Response;

public class LmKeywordDto : LmDto
{
    [JsonPropertyName("response")]
    public List<LmKeywordDto> Keywords { get; set; }
}

public class LmKeywordDto
{
    [JsonPropertyName("kljucna_rec")]
    public string Keyword { get; set; }

    [JsonPropertyName("objasnjenje")]
    public string Explanation { get; set; }
}
