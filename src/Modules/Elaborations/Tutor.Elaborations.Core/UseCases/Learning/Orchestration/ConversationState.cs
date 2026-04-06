namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class ConversationState
{
    public bool IsCompleted { get; set; }
    public bool IsSoftCapReached { get; set; }
    public bool IsHardCapReached { get; set; }
    public List<int> UncoveredKeyPropositionIds { get; set; } = new();
    public List<int> UnarticulatedKeyRelationIds { get; set; } = new();
}
