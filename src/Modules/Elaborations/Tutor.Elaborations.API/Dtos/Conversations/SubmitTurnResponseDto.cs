namespace Tutor.Elaborations.API.Dtos.Conversations;

public class SubmitTurnResponseDto
{
    public int AttemptId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Summary { get; set; }
}
