using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.AssessmentItems;

public abstract class Submission : ValueObject
{
    public int ReattemptCount { get; private set; }
}