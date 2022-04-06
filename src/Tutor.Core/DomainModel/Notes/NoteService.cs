using System.Collections.Generic;
using FluentResults;

namespace Tutor.Core.DomainModel.Notes
{
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

        public Result<int> Delete(int id)
        {
            var note = _noteRepository.FindById(id);
            return Result.Ok(_noteRepository.Delete(note));
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
}