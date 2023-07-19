using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class LearnerGroup : Entity
{
    public string Name { get; private set; }
    public List<GroupMembership> Membership { get; private set; }
    public int CourseId { get; private set; }
    public Course Course { get; private set; }
}