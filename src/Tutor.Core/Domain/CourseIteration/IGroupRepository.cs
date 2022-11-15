using System.Collections.Generic;

namespace Tutor.Core.Domain.CourseIteration;

public interface IGroupRepository
{
    List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId);
    int CountLearnersEnrolledInUnit(int unitId, List<int> learnerIds);
}