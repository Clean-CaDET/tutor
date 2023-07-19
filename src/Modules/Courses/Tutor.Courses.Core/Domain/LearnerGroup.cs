using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class LearnerGroup : Entity
{
    public string Name { get; private set; }
    public HashSet<int> LearnerIds { get; private set; }
    public int CourseId { get; private set; }
    public Course Course { get; private set; }

    internal void AddMembers(List<int> learnerIds)
    {
        LearnerIds.UnionWith(learnerIds);
    }

    internal void RemoveMember(int learnerId)
    {
        LearnerIds.Remove(learnerId);
    }
}