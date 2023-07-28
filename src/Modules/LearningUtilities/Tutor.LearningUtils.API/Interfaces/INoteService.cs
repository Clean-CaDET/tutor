using FluentResults;
using Tutor.LearningUtils.API.Dtos;

namespace Tutor.LearningUtils.API.Interfaces;

public interface INoteService
{
    Result<NoteDto> Create(NoteDto note);
    Result<NoteDto> Update(NoteDto note);
    Result<List<NoteDto>> GetAppropriateNotes(int learnerId, int unitId);
    Result Delete(int noteId, int learnerId);
    Result<byte[]> GetNotesExport(int learnerId, int unitId);
}