using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Infrastructure.Database.Repositories;

public class NoteDatabaseRepository : CrudDatabaseRepository<Note, LearningUtilitiesContext>, INoteRepository
{
    public NoteDatabaseRepository(LearningUtilitiesContext dbContext): base(dbContext) {}
    
    public List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId)
    {
        return DbContext.Notes
            .Where(e => e.LearnerId == learnerId && e.UnitId == unitId)
            .ToList();
    }
}