using Tutor.Elaborations.API.Dtos.Conversations;

namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class ConceptElaborationTaskDto
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CanonicalDefinition { get; set; } = string.Empty;
    public List<KeyPropositionDto> KeyPropositions { get; set; } = new();
    public List<BoundaryConditionDto> BoundaryConditions { get; set; } = new();
    public List<CommonMisconceptionDto> CommonMisconceptions { get; set; } = new();
    public List<KeyRelationDto> KeyRelations { get; set; } = new();
    public List<ConversationAttemptDto>? Attempts { get; set; }
}
