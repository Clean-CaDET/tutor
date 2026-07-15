namespace Tutor.Elaborations.API.Dtos.Conversations;

public class ConversationRoundDto
{
    public int Order { get; set; }
    public string ElaborationContent { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }
    public string? FeedbackContent { get; set; }
}
