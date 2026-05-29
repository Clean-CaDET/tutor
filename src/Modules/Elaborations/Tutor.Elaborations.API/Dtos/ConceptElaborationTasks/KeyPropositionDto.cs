namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class KeyPropositionDto
{
    public string Key { get; set; } = string.Empty;
    public string Statement { get; set; } = string.Empty;
    public MisconceptionDto? Misconception { get; set; }
}
