﻿using System.Collections.Generic;
using System.Linq;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Infrastructure.Database.Repositories.LearningUtilities;

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

    public int? Delete(int id)
    {
        var note = _dbContext.Notes.Find(id);
        if (note == null)
        {
            return null;
        }

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