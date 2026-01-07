namespace Tutor.BuildingBlocks.AI.Core.Conversations;

public record ChatMessage(ChatRole Role, string Content)
{
    public static ChatMessage FromUser(string content) => new(ChatRole.User, content);
    public static ChatMessage FromAssistant(string content) => new(ChatRole.Assistant, content);
    public static ChatMessage FromSystem(string content) => new(ChatRole.System, content);
}

public enum ChatRole
{
    System,
    User,
    Assistant
}
