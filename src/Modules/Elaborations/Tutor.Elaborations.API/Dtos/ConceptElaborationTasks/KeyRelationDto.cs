namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class KeyRelationDto
{
    public int Id { get; set; }
    public int SourceKeyPropositionId { get; set; }
    public int TargetKeyPropositionId { get; set; }
    public int? SourceKeyPropositionIndex { get; set; }
    public int? TargetKeyPropositionIndex { get; set; }
    public string Mechanism { get; set; } = string.Empty;
}
