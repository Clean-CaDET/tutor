using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.Notes;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class NoteRepository : INoteRepository
    {
        private readonly TutorContext _dbContext;

        public NoteRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Note Save(Note note)
        {
            _dbContext.Notes.Attach(note);
            _dbContext.SaveChanges();
            return note;
        }

        public Note FindById(int id)
        {
            return _dbContext.Notes.Find(id);
        }

        public int Delete(Note note)
        {
            _dbContext.Remove(note);
            _dbContext.SaveChanges();
            return note.Id;
        }

        public Note Update(Note note)
        {
            _dbContext.Update(note);
            _dbContext.SaveChanges();
            return note;
        }

        public List<Note> GetNotesByLearnerAndUnit(int learnerId, int unitId)
        {
            return _dbContext.Notes
                .Where(e => e.LearnerId == learnerId && e.UnitId == unitId)
                .ToList();
        }
    }
}