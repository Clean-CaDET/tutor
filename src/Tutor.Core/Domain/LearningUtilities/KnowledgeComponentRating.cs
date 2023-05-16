using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.LearningUtilities;

public class KnowledgeComponentRating : Entity
{
    public int LearnerId { get; private set; }
    public int KnowledgeComponentId { get; private set; }
    public int Rating { get; private set; }
    public string[] Tags { get; private set; }
}