using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.LearnerModel.Notes
{
    public interface INoteService
    {
        Result<Note> Save(Note note);

        Result<int?> Delete(int id);

        Result<Note> Update(Note note);

        Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId);
    }
}