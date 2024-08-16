using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class UnitEnrollment : Entity
{
    public int LearnerId { get; private set; }
    public int KnowledgeUnitId { get; private set; }
    public KnowledgeUnit KnowledgeUnit { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime? BestBefore { get; private set; }
    public EnrollmentStatus Status { get; internal set; }

    private UnitEnrollment() { }

    public UnitEnrollment(int learnerId, DateTime availableFrom, DateTime? bestBefore, KnowledgeUnit knowledgeUnit)
    {
        LearnerId = learnerId;
        KnowledgeUnitId = knowledgeUnit.Id;
        KnowledgeUnit = knowledgeUnit;
        Start = availableFrom;
        BestBefore = bestBefore;
        Status = EnrollmentStatus.Active;
    }

    public bool IsAccessible()
    {
        return (Status == EnrollmentStatus.Active || Status == EnrollmentStatus.Completed)
               && Start < DateTime.Now;
    }

    public void Activate(DateTime availableFrom, DateTime? bestBefore)
    {
        if (Status == EnrollmentStatus.Active) return;

        Status = EnrollmentStatus.Active;
        Start = availableFrom;
        BestBefore = bestBefore;
    }
}

public enum EnrollmentStatus
{
    Deactivated, Active, Completed
}