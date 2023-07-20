using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningUtils.Core.Domain;

public class ImprovementFeedback : Entity
{
    public int LearnerId { get; private set; }
    public int UnitId { get; private set; }
    public string SoftwareComment { get; private set; }
    public string ContentComment { get; private set; }
    public DateTime TimeStamp { get; private set; } = DateTime.Now.ToUniversalTime();
}