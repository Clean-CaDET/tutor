using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningUtils.Core.Domain;

public class EmotionsFeedback : Entity
{
    public int Id { get; private set; }
    public int LearnerId { get; private set; }
    public int KnowledgeComponentId { get; private set; }
    public string Comment { get; private set; }
    public DateTime TimeStamp { get; private set; } = DateTime.Now.ToUniversalTime();
}