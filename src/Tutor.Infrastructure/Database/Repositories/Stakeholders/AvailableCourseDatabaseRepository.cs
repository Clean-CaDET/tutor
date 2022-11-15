using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.Stakeholders;

public class AvailableCourseDatabaseRepository : IAvailableCourseRepository
{
    private readonly TutorContext _dbContext;

    public AvailableCourseDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Course> GetOwnedCourses(int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.Instructor.Id.Equals(instructorId))
            .Select(m => m.Course).ToList();
    }

    public Course GetOwnedCourseWithUnits(int courseId, int instructorId)
    {
        return _dbContext.CourseOwnerships
            .Where(m => m.Instructor.Id.Equals(instructorId) && m.Course.Id.Equals(courseId))
            .Include(m => m.Course.KnowledgeUnits)
            .Select(m => m.Course).FirstOrDefault();
    }

    public List<Course> GetEnrolledCourses(int learnerId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.Membership.Any(m => m.Learner.Id.Equals(learnerId)))
            .Select(lg => lg.Course).Distinct().ToList();
    }
}