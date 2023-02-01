using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Infrastructure.Database.Repositories.LearningUtilities;

public class NoteRepository : CrudDatabaseRepository<Note>, INoteRepository
{
    public NoteRepository(TutorContext dbContext): base(dbContext) {}
    
    public List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId)
    {
        return DbContext.Notes
            .Where(e => e.LearnerId == learnerId && e.UnitId == unitId)
            .ToList();
    }
}