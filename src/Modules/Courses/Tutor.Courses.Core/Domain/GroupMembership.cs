using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class GroupMembership : Entity
{
    // TODO: Consider removing this class and adding a List<int> in Group
    public int LearnerGroupId { get; private set; }
    public int LearnerId { get; private set; }

    private GroupMembership() {}

    public GroupMembership(int learnerId, int learnerGroupId)
    {
        LearnerId = learnerId;
        LearnerGroupId = learnerGroupId;
    }
}
