namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class ConversationState
{
    public bool IsCompleted { get; set; }
    public bool IsSoftCapReached { get; set; }
    public bool IsHardCapReached { get; set; }
}
