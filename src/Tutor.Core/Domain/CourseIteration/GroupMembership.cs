using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public class GroupMembership : Entity
{
    public int LearnerGroupId { get; private set; }
    public Learner Member { get; private set; }

    private GroupMembership() {}

    public GroupMembership(Learner member, int learnerGroupId)
    {
        Member = member;
        LearnerGroupId = learnerGroupId;
    }
}
