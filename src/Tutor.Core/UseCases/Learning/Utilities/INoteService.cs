using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public interface INoteService
{
    Result<Note> Create(Note note);
    Result<Note> Update(Note note);
    Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId);
    Result Delete(int noteId, int learnerId);
    Result<byte[]> GetNotesExport(int learnerId, int unitId);
}