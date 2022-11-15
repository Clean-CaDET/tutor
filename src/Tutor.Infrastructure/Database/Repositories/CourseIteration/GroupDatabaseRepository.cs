using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Infrastructure.Database.Repositories.CourseIteration;

public class GroupDatabaseRepository : IGroupRepository
{
    private readonly TutorContext _dbContext;

    public GroupDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.Course.Id.Equals(courseId))
            .Include(lg => lg.Membership
                .Where(m => m.Instructor.Id.Equals(instructorId))).ToList();
    }


    public int CountLearnersEnrolledInUnit(int unitId, List<int> learnerIds)
    {
        if (learnerIds == null)
            return _dbContext.UnitEnrollments.Count(enrollment => enrollment.KnowledgeUnit.Id == unitId);
        return _dbContext.UnitEnrollments.Count(enrollment =>
            enrollment.KnowledgeUnit.Id == unitId && learnerIds.Contains(enrollment.LearnerId));
    }
}