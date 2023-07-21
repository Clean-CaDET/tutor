using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningUtils.Core.Domain;

public class KnowledgeComponentRating : Entity
{
    public int LearnerId { get; private set; }
    public int KnowledgeComponentId { get; private set; }
    public int Rating { get; private set; }
    public string[] Tags { get; private set; }
}