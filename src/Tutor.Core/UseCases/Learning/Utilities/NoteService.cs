using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public Result<Note> Save(Note note)
    {
        return Result.Ok(_noteRepository.Save(note));
    }

    public Result<int?> Delete(int id)
    {
        var removedId = _noteRepository.Delete(id);
        return removedId == null ? Result.Fail("No note with ID" + id) : Result.Ok(removedId);
    }

    public Result<Note> Update(Note note)
    {
        return Result.Ok(_noteRepository.Update(note));
    }

    public Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId)
    {
        return Result.Ok(_noteRepository.GetNotesByLearnerAndUnit(learnerId, unitId));
    }
}