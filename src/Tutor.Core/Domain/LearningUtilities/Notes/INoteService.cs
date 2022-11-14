using FluentResults;
using System.Collections.Generic;

namespace Tutor.Core.Domain.LearningUtilities.Notes
{
    public interface INoteService
    {
        Result<Note> Save(Note note);

        Result<int?> Delete(int id);

        Result<Note> Update(Note note);

        Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId);
    }
}