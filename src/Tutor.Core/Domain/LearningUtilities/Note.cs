using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.LearningUtilities;

public class Note : Entity
{
    public int LearnerId { get; set; }
    public int UnitId { get; set; }
    public string Text { get; set; }
}