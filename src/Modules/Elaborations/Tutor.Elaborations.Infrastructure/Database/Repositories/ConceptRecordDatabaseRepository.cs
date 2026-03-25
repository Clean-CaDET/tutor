using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Infrastructure.Database.Repositories;

public class ConceptRecordDatabaseRepository :
    CrudDatabaseRepository<ConceptRecord, ElaborationsContext>, IConceptRecordRepository
{
    public ConceptRecordDatabaseRepository(ElaborationsContext dbContext) : base(dbContext) { }

    public new ConceptRecord? Get(int id)
    {
        return DbContext.ConceptRecords
            .Include(cr => cr.KeyPropositions.OrderBy(kp => kp.Order))
            .Include(cr => cr.BoundaryConditions.OrderBy(bc => bc.Order))
            .Include(cr => cr.CommonMisconceptions.OrderBy(cm => cm.Order))
            .FirstOrDefault(cr => cr.Id == id);
    }

    public List<ConceptRecord> GetByCourse(int courseId)
    {
        return DbContext.ConceptRecords
            .Include(cr => cr.KeyPropositions.OrderBy(kp => kp.Order))
            .Include(cr => cr.BoundaryConditions.OrderBy(bc => bc.Order))
            .Include(cr => cr.CommonMisconceptions.OrderBy(cm => cm.Order))
            .Where(cr => cr.CourseId == courseId)
            .ToList();
    }
}
