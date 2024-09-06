using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.Repositories;

public class KnowledgeComponentDatabaseRepository : CrudDatabaseRepository<KnowledgeComponent, KnowledgeComponentsContext>, IKnowledgeComponentRepository
{
    public KnowledgeComponentDatabaseRepository(KnowledgeComponentsContext dbContext) : base(dbContext) {}

    public List<KnowledgeComponent> GetByUnit(int unitId)
    {
        return DbContext.KnowledgeComponents.Where(kc => kc.KnowledgeUnitId == unitId).ToList();
    }

    public List<KnowledgeComponent> GetByUnitWithAssessments(int unitId)
    {
        return DbContext.KnowledgeComponents
            .Include(kc => kc.AssessmentItems)
            .Where(kc => kc.KnowledgeUnitId == unitId).ToList();
    }

    public List<KnowledgeComponent> GetByUnits(int[] unitIds)
    {
        return DbContext.KnowledgeComponents
            .Where(kc => unitIds.Contains(kc.KnowledgeUnitId)).ToList();
    }

    public List<KnowledgeComponent> GetByUnitsWithItems(List<int> unitIds)
    {
        return DbContext.KnowledgeComponents
            .Include(kc => kc.InstructionalItems)
            .Include(kc => kc.AssessmentItems)
            .Where(kc => unitIds.Contains(kc.KnowledgeUnitId)).ToList();
    }

    public List<KnowledgeComponent> GetRootKcs(List<int> unitIds)
    {
        return DbContext.KnowledgeComponents
            .Where(kc => kc.ParentId == null && unitIds.Contains(kc.KnowledgeUnitId))
            .ToList();
    }
}