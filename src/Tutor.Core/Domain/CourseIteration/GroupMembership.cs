using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.Domain.CourseIteration;

public class GroupMembership : Entity
{
    public int LearnerGroupId { get; set; }
    public Learner Member { get; set; }
}
