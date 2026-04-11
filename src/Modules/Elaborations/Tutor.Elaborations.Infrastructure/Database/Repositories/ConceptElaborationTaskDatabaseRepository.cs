using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Infrastructure.Database.Repositories;

public class ConceptElaborationTaskDatabaseRepository :
    CrudDatabaseRepository<ConceptElaborationTask, ElaborationsContext>, IConceptElaborationTaskRepository
{
    public ConceptElaborationTaskDatabaseRepository(ElaborationsContext dbContext) : base(dbContext) { }

    public new ConceptElaborationTask? Get(int id)
    {
        return DbContext.ConceptElaborationTasks
            .Include(cet => cet.KeyPropositions)
            .Include(cet => cet.BoundaryConditions)
            .Include(cet => cet.CommonMisconceptions)
            .Include(cet => cet.KeyRelations)
            .FirstOrDefault(cet => cet.Id == id);
    }

    public List<ConceptElaborationTask> GetByUnit(int unitId)
    {
        return DbContext.ConceptElaborationTasks
            .Include(cet => cet.KeyPropositions)
            .Include(cet => cet.BoundaryConditions)
            .Include(cet => cet.CommonMisconceptions)
            .Include(cet => cet.KeyRelations)
            .Where(cet => cet.UnitId == unitId)
            .OrderBy(cet => cet.Order)
            .ToList();
    }
}
