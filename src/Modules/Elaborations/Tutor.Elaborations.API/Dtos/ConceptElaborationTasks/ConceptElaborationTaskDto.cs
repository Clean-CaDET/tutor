using Tutor.Elaborations.API.Dtos.Conversations;

namespace Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;

public class ConceptElaborationTaskDto
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ConceptRecordDto ConceptRecord { get; set; } = new();
    public List<ConversationAttemptDto>? Attempts { get; set; }
}
