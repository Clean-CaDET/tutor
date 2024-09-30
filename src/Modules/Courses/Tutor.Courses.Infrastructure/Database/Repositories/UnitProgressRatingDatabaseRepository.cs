using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class UnitProgressRatingRepository : IUnitProgressRatingRepository
{
    private readonly CoursesContext _dbContext;

    public UnitProgressRatingRepository(CoursesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<UnitProgressRating> GetByUnitAndLearner(int unitId, int learnerId)
    {
        return _dbContext.UnitProgressRating
            .Where(r => r.KnowledgeUnitId == unitId && r.LearnerId == learnerId)
            .OrderByDescending(r => r.Created)
            .ToList();
    }

    public UnitProgressRating Create(UnitProgressRating rating)
    {
        _dbContext.UnitProgressRating.Add(rating);
        return rating;
    }

    public List<UnitProgressRating> GetInDateRangeForUnits(int[] unitIds, DateTime start, DateTime end)
    {
        return _dbContext.UnitProgressRating
            .Where(r => unitIds.Contains(r.KnowledgeUnitId) && r.Created > start && r.Created < end)
            .ToList();
    }
}