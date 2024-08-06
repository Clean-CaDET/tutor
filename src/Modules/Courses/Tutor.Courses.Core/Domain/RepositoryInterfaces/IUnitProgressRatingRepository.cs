﻿namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IUnitProgressRatingRepository
{
    List<UnitProgressRating> GetByUnitAndLearner(int unitId, int learnerId);
    UnitProgressRating Create(UnitProgressRating rating);
}