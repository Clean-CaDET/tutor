namespace Tutor.Elaborations.API.Dtos.Conversations;

public class ConversationTurnDto
{
    public int Id { get; set; }
    public string Role { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Order { get; set; }
    public DateTime Timestamp { get; set; }
}
