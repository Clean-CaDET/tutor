using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public static class LanguageModelConsts
{
    public static readonly string BaseApi = Environment.GetEnvironmentVariable("LANGUAGE_MODEL_API") ?? "http://localhost:8080/api/";

    public static readonly Dictionary<MessageType, string> Endpoints = new()
    {
        { MessageType.TopicConversation, "topic-conversation" },
        { MessageType.GenerateSimilar, "generate-similar" },
        { MessageType.Summarize, "summarize" },
        { MessageType.ExtractKeywords, "extract-keywords" },
        { MessageType.GenerateQuestions, "generate-questions" },
    };

    public static readonly string TaskTitle = "\n# TEKST ZADATKA:\n";
    public static readonly string TaskAnswerTitle = "\n## PONUĐENI ODGOVORI:\n";
    public static readonly string TaskAnswer = "\nIzbor: ";
    public static readonly string TaskCorrectAnswer = "\nOdgovor: tačno. ";
    public static readonly string TaskIncorrectAnswer = "\nOdgovor: netačno. ";
}
