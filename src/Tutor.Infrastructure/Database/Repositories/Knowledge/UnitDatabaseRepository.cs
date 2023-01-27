using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class UnitDatabaseRepository : CrudDatabaseRepository<KnowledgeUnit>, IUnitRepository
{
    public UnitDatabaseRepository(TutorContext dbContext) : base(dbContext) {}
    
    public List<KnowledgeUnit> GetByCourseId(int courseId)
    {
        return DbContext.KnowledgeUnits.Where(u => u.CourseId == courseId).ToList();
    }

    public KnowledgeUnit GetUnitWithKcs(int unitId)
    {
        return DbContext.KnowledgeUnits
            .Where(u => u.Id == unitId)
            .Include(u => u.KnowledgeComponents)
            .FirstOrDefault();
    }
}