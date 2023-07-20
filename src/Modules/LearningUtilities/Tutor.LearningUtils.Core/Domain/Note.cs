using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningUtils.Core.Domain;

public class Note : Entity
{
    public int LearnerId { get; set; }
    public int UnitId { get; set; }
    public string Text { get; set; }
}