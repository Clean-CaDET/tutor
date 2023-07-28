using System.Text.Json.Serialization;

namespace Tutor.LmConversations.API.Dtos.Integration.Response;

public class LmKeywordResponse : LmResponse
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
