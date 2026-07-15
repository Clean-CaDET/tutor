namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class LearnerElaborationSummaryDto
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool HasCompletedAttempt { get; set; }
}
