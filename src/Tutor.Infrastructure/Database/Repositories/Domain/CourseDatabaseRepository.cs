using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Domain;

public class CourseDatabaseRepository : ICourseRepository
{
    private readonly TutorContext _dbContext;
    
    public CourseDatabaseRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Course GetCourse(int id)
    {
        return _dbContext.Courses
            .Include(c => c.KnowledgeUnits)
            .FirstOrDefault(c => c.Id.Equals(id));
    }

    public List<Course> GetCoursesByLearner(int learnerId)
    {
        return _dbContext.LearnerGroups
            .Where(lg => lg.Membership.Any(m => m.Learner.Id.Equals(learnerId)))
            .Select(lg => lg.Course).Distinct().ToList();
    }
}