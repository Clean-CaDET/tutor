namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public static class LanguageModelEndpoints
{
    // TODO: izvuci kao konfiguraciju (docker varijabla?)
    public static readonly string BaseApi = "http://localhost:8080/api/";
    public static readonly string TopicConversation = "topic-conversation";
    public static readonly string GenerateSimilar = "generate-similar";
    public static readonly string Summarize = "summarize";
    public static readonly string ExtractKeywords = "extract-keywords";
    public static readonly string GenerateQuestions = "generate-questions";
}
