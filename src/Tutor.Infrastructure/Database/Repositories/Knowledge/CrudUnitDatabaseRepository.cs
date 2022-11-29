using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class CrudUnitDatabaseRepository : CrudDatabaseRepository<KnowledgeUnit>, ICrudUnitRepository
{
    public CrudUnitDatabaseRepository(TutorContext dbContext) : base(dbContext) {}
    
    public Result<List<KnowledgeUnit>> GetByCourseId(int courseId)
    {
        return DbContext.KnowledgeUnits.Where(u => u.CourseId == courseId).ToList();
    }
}