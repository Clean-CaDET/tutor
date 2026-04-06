namespace Tutor.Elaborations.API.Dtos.ConceptRecords;

public class KeyRelationDto
{
    public int Id { get; set; }
    public int SourceKeyPropositionId { get; set; }
    public int TargetKeyPropositionId { get; set; }
    public string Mechanism { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public int Order { get; set; }
}
