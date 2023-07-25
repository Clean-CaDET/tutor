using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;

public abstract class Submission : ValueObject
{
    public int ReattemptCount { get; protected set; }
}