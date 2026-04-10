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
            .Include(cr => cr.KeyPropositions)
            .Include(cr => cr.BoundaryConditions)
            .Include(cr => cr.CommonMisconceptions)
            .Include(cr => cr.KeyRelations)
            .FirstOrDefault(cr => cr.Id == id);
    }

    public List<ConceptRecord> GetByCourse(int courseId)
    {
        return DbContext.ConceptRecords
            .Include(cr => cr.KeyPropositions)
            .Include(cr => cr.BoundaryConditions)
            .Include(cr => cr.CommonMisconceptions)
            .Include(cr => cr.KeyRelations)
            .Where(cr => cr.CourseId == courseId)
            .ToList();
    }
}
