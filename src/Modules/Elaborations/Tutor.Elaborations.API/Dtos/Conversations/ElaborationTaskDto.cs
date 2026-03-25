namespace Tutor.Elaborations.API.Dtos.Conversations;

public class ElaborationTaskDto
{
    public int Id { get; set; }
    public int ConceptRecordId { get; set; }
    public int UnitId { get; set; }
    public string ExpectedLevel { get; set; } = string.Empty;
    public int Order { get; set; }
    public string? ConceptRecordTitle { get; set; }
}
