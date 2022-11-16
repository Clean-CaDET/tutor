using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database.Repositories.Stakeholders;

public class OwnedCourseDatabaseRepository : IOwnedCourseRepository
{
    private readonly TutorContext _dbContext;

    public OwnedCourseDatabaseRepository(TutorContext dbContext)
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
}