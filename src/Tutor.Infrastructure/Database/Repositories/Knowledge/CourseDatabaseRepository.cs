using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

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
}