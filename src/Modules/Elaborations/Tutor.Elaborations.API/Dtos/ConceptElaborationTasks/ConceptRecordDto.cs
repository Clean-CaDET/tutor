namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class ConceptRecordDto
{
    public string CanonicalDefinition { get; set; } = string.Empty;
    public List<KeyPropositionDto> KeyPropositions { get; set; } = new();
    public List<BoundaryConditionDto> BoundaryConditions { get; set; } = new();
    public List<CommonMisconceptionDto> CommonMisconceptions { get; set; } = new();
    public List<KeyRelationDto> KeyRelations { get; set; } = new();
}
