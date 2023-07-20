using System.Text;
using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningUtils.API.Dtos;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Core.UseCases;

public class NoteService : CrudService<NoteDto, Note>, INoteService
{

    private INoteRepository _noteRepository;
    
    public NoteService(ICrudRepository<Note> crudRepository, IUnitOfWork unitOfWork, IMapper mapper, INoteRepository noteRepository) : base(crudRepository, unitOfWork, mapper)
    {
        _noteRepository = noteRepository;
    }

    public Result<List<NoteDto>> GetAppropriateNotes(int learnerId, int unitId)
    {
        return MapToDto(_noteRepository.GetNotesByLearnerAndUnit(learnerId, unitId));
    }

    public Result Delete(int noteId, int learnerId)
    {
        var note = _noteRepository.Get(noteId);
        return note.LearnerId != learnerId ? Result.Fail(FailureCode.Forbidden) : Delete(noteId);
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