namespace Tutor.Elaborations.API.Dtos.Conversations;

public class ConversationAttemptDto
{
    public int Id { get; set; }
    public int ConceptElaborationTaskId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public double? FinalGrade { get; set; }
    public List<ConversationRoundDto> Rounds { get; set; } = new();
}
