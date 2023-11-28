using System;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningUtils.Core.Domain;

public class Emotion : Entity
{ 
    public int LearnerId { get; set; }
    public DateTime TimeStamp { get; private set; } = DateTime.UtcNow;
    public string? Value { get; set; }
}
