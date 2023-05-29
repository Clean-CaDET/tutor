using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.CourseIteration;

public class UnitEnrollment : Entity
{
    public int LearnerId { get; private set; }
    public int KnowledgeUnitId { get; private set; }
    public KnowledgeUnit KnowledgeUnit { get; private set; }
    public DateTime Start { get; private set; }
    public EnrollmentStatus Status { get; internal set; }

    private UnitEnrollment() {}

    public UnitEnrollment(int learnerId, int knowledgeUnitId)
    {
        LearnerId = learnerId;
        KnowledgeUnitId = knowledgeUnitId;
        Start = DateTime.UtcNow;
        Status = EnrollmentStatus.Active;
    }

    public bool IsActive()
    {
        return Status == EnrollmentStatus.Active && Start < DateTime.Now;
    }
}

public enum EnrollmentStatus
{
    Hidden, Active, Passed
}