using System.Text.Json.Serialization;

namespace Tutor.LanguageModelConversations.API.Dtos;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContextType
{
    Lecture,
    Task
}
