namespace Tutor.Elaborations.API.Dtos.Conversations;

public class ElaborationTaskDetailDto
{
    public int Id { get; set; }
    public string ExpectedLevel { get; set; } = string.Empty;
    public int Order { get; set; }
    public string ConceptTitle { get; set; } = string.Empty;
    public string ConceptDefinition { get; set; } = string.Empty;
    public List<ConversationAttemptDto> Attempts { get; set; } = new();
}
