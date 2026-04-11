namespace Tutor.Elaborations.API.Dtos.Conversations;

public class ConversationAttemptDto
{
    public int Id { get; set; }
    public int ConceptElaborationTaskId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? Summary { get; set; }
    public List<ConversationTurnDto> Turns { get; set; } = new();
}
