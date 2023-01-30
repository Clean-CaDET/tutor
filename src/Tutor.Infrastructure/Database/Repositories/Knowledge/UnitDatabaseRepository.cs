using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Infrastructure.Database.Repositories.Knowledge;

public class UnitDatabaseRepository : CrudDatabaseRepository<KnowledgeUnit>, IUnitRepository
{
    public UnitDatabaseRepository(TutorContext dbContext) : base(dbContext) {}
    
    public KnowledgeUnit GetUnitWithKcs(int unitId)
    {
        return DbContext.KnowledgeUnits
            .Where(u => u.Id == unitId)
            .Include(u => u.KnowledgeComponents)
            .FirstOrDefault();
    }

    public KnowledgeUnit GetUnitWithKcsAndAssessments(int unitId)
    {
        return DbContext.KnowledgeUnits
            .Where(u => u.Id == unitId)
            .Include(u => u.KnowledgeComponents)
            .ThenInclude(kc => kc.AssessmentItems)
            .FirstOrDefault();
    }
}