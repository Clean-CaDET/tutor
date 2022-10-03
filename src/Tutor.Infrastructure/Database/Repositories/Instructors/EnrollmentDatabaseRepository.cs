using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.EnrollmentModel;

namespace Tutor.Infrastructure.Database.Repositories.Instructors;

public class EnrollmentDatabaseRepository : IEnrollmentRepository
{
    private readonly TutorContext _dbContext;

    public EnrollmentDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Instructor GetByUserId(int userId)
    {
        return _dbContext.Instructors.FirstOrDefault(i => i.UserId.Equals(userId));
    }

    public List<Course> GetOwnedCourses(int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.Instructor.Id.Equals(instructorId))
            .Include(m => m.Course.KnowledgeUnits)
            .Select(m => m.Course).ToList();
    }

    public List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId)
    {
        return _dbContext.LearnerGroups.Include(lg => lg.Membership)
            .Where(lg => lg.CourseId.Equals(courseId) && lg.Membership.Any(m => m.Instructor.Id.Equals(instructorId)))
            .ToList();
    }
}