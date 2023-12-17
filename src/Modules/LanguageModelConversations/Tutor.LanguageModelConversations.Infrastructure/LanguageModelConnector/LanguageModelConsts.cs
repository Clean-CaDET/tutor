using System.Collections.Immutable;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public static class LanguageModelConsts
{
    public static readonly string BaseApi = Environment.GetEnvironmentVariable("LANGUAGE_MODEL_API") ?? "http://localhost:8080/api/";

    public static readonly ImmutableDictionary<MessageType, string> Endpoints = 
        new Dictionary<MessageType, string>()
        {
            { MessageType.TopicConversation, "topic-conversation" },
            { MessageType.GenerateSimilar, "generate-similar" },
            { MessageType.Summarize, "summarize" },
            { MessageType.ExtractKeywords, "extract-keywords" },
            { MessageType.GenerateQuestions, "generate-questions" },
        }.ToImmutableDictionary();

    public static readonly string TaskTitle = "\n# TEKST ZADATKA:\n";
    public static readonly string TaskAnswersTitle = "\n## PONUĐENI ODGOVORI:\n";
    public static readonly string TaskAnswer = "\nIzbor: ";
    public static readonly string TaskCorrectAnswer = "\nOdgovor: tačno. ";
    public static readonly string TaskIncorrectAnswer = "\nOdgovor: netačno. ";
}
