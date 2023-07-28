using System.Text.Json.Serialization;

namespace Tutor.LmConversations.API.Dtos;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContextType
{
    Lecture,
    Task
}
