using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.CourseIteration;

public class UnitEnrollment : Entity
{
    public int LearnerId { get; private set; }
    public KnowledgeUnit KnowledgeUnit { get; private set; }
    public DateTime Start { get; private set; }
    public EnrollmentStatus Status { get; private set; }
}

public enum EnrollmentStatus
{
    Hidden, Active, Passed
}