using System.Collections.Generic;

namespace Tutor.Core.DomainModel.Notes
{
    public interface INoteRepository
    {
        Note Save(Note note);

        Note FindById(int id);
        
        int Delete(Note note);

        Note Update(Note note);

        List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId);
    }
}