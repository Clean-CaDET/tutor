namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class KeyRelationDto
{
    public string Key { get; set; } = string.Empty;
    public string SourceKey { get; set; } = string.Empty;
    public string TargetKey { get; set; } = string.Empty;
    public string Mechanism { get; set; } = string.Empty;
}
