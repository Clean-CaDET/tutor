using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Infrastructure.Database.Repositories;

public class ConceptElaborationTaskDatabaseRepository :
    CrudDatabaseRepository<ConceptElaborationTask, ElaborationsContext>, IConceptElaborationTaskRepository
{
    public ConceptElaborationTaskDatabaseRepository(ElaborationsContext dbContext) : base(dbContext) { }

    public ConceptElaborationTask? GetWithRecord(int id)
    {
        return DbContext.ConceptElaborationTasks
            .Include(cet => cet.ConceptRecord)
            .FirstOrDefault(cet => cet.Id == id);
    }

    public List<ConceptElaborationTask> GetByUnit(int unitId)
    {
        return DbContext.ConceptElaborationTasks
            .Where(cet => cet.UnitId == unitId)
            .OrderBy(cet => cet.Order)
            .ToList();
    }

    public List<ConceptElaborationTask> GetByUnitWithRecords(int unitId)
    {
        return DbContext.ConceptElaborationTasks
            .Include(cet => cet.ConceptRecord)
            .Where(cet => cet.UnitId == unitId)
            .OrderBy(cet => cet.Order)
            .ToList();
    }
}
