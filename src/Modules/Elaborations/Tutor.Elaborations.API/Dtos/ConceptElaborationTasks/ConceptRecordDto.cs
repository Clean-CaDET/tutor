namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class ConceptRecordDto
{
    public string CanonicalDefinition { get; set; } = string.Empty;
    public List<KeyPropositionDto> KeyPropositions { get; set; } = new();
}
