using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.API.Dtos.Integration.Response;

public class LmQaResponse : LmResponse
{
    [JsonPropertyName("response")]
    public List<LmQaDto> QuestionAnswers { get; set; }
}

public class LmQaDto
{
    [JsonPropertyName("pitanje")]
    public string Question { get; set; }

    [JsonPropertyName("odgovor")]
    public string Answer { get; set; }
}
