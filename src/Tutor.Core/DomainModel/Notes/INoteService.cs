using System.Collections.Generic;
using FluentResults;

namespace Tutor.Core.DomainModel.Notes
{
    public interface INoteService
    {
        Result<Note> Save(Note note);

        Result<int?> Delete(int id);

        Result<Note> Update(Note note);

        Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId);
    }
}