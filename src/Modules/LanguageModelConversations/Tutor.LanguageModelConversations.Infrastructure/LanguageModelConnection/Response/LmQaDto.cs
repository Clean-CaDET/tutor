using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Response;

public class LmQaDto : LmDto
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
