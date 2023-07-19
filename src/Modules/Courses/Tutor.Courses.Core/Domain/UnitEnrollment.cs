using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class UnitEnrollment : Entity
{
    public int LearnerId { get; private set; }
    public KnowledgeUnit KnowledgeUnit { get; private set; } //TODO: Analyze if this can be turned into ID without losing too much in repos
    public DateTime Start { get; internal set; }
    public EnrollmentStatus Status { get; internal set; }

    private UnitEnrollment() {}

    public UnitEnrollment(int learnerId, DateTime start, KnowledgeUnit knowledgeUnit)
    {
        LearnerId = learnerId;
        KnowledgeUnit = knowledgeUnit;
        Start = start;
        Status = EnrollmentStatus.Active;
    }

    public bool IsActive()
    {
        return Status == EnrollmentStatus.Active && Start < DateTime.Now;
    }
}

public enum EnrollmentStatus
{
    Deactivated, Active, Completed
}