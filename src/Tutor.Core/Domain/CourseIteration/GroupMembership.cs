using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public class GroupMembership : Entity
{
    public int LearnerGroupId { get; set; }
    public Stakeholder Member { get; set; }
    public Role Role { get; private set; }
}

public enum Role
{
    Learner,
    Instructor
}