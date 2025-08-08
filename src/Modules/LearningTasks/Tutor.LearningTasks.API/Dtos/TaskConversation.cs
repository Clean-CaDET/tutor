using Tutor.BuildingBlocks.Core.Domain;
using Tutor.BuildingBlocks.Core.LLM;

namespace Tutor.LearningTasks.API.Dtos;

public class TaskConversationDto : Entity
{
    public int LearningTaskId { get; set; }
    public int LearnerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<LlmMessage> Messages { get; set; }
}