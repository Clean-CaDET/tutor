using FluentResults;
using System.Collections.Generic;
using System.Text;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public class NoteService : CrudService<Note>, INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository, IUnitOfWork unitOfWork) : base(noteRepository, unitOfWork)
    {
        _noteRepository = noteRepository;
    }
    
    public Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId)
    {
        return Result.Ok(_noteRepository.GetNotesByLearnerAndUnit(learnerId, unitId));
    }

    public Result Delete(int noteId, int learnerId)
    {
        var note = _noteRepository.Get(noteId);
        if (note.LearnerId != learnerId) return Result.Fail(FailureCode.Forbidden);
        return Delete(noteId);
    }

    public Result<byte[]> GetNotesExport(int learnerId, int unitId)
    {
        var notes = _noteRepository.GetNotesByLearnerAndUnit(learnerId, unitId);
        var notesSb = new StringBuilder();
        foreach (var note in notes)
        {
            notesSb.Append(note.Text);
            notesSb.Append("\n\n---\n");
        }
        var utf8 = new UTF8Encoding();
        return utf8.GetBytes(notesSb.ToString());
    }
}