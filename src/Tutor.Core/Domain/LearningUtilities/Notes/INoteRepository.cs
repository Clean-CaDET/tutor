using System.Collections.Generic;

namespace Tutor.Core.Domain.LearningUtilities.Notes
{
    public interface INoteRepository
    {
        Note Save(Note note);

        int? Delete(int id);

        Note Update(Note note);

        List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId);
    }
}