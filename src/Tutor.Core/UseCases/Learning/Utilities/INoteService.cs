﻿using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Core.UseCases.Learning.Utilities;

public interface INoteService
{
    Result<Note> Save(Note note);

    Result<int?> Delete(int id);

    Result<Note> Update(Note note);

    Result<List<Note>> GetAppropriateNotes(int learnerId, int unitId);
}