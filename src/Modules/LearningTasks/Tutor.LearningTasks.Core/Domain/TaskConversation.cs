using Tutor.BuildingBlocks.Core.Domain;
using Tutor.BuildingBlocks.Core.LLM;

namespace Tutor.LearningTasks.Core.Domain;

public class TaskConversation : Entity
{
    public int LearningTaskId { get; private set; }
    public int LearnerId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<LlmMessage> Messages { get; private set; }

    private TaskConversation() 
    {
        Messages = new List<LlmMessage>();
    }

    public TaskConversation(int learningTaskId, int learnerId)
    {
        LearningTaskId = learningTaskId;
        LearnerId = learnerId;
        CreatedAt = DateTime.UtcNow;
        Messages = new List<LlmMessage>();
    }
}