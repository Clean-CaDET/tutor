namespace Tutor.Elaborations.API.Dtos.ConceptRecords;

public class ConceptRecordDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CanonicalDefinition { get; set; } = string.Empty;
    public List<KeyPropositionDto> KeyPropositions { get; set; } = new();
    public List<BoundaryConditionDto> BoundaryConditions { get; set; } = new();
    public List<CommonMisconceptionDto> CommonMisconceptions { get; set; } = new();
    public List<KeyRelationDto> KeyRelations { get; set; } = new();
}
