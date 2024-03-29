using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.Repositories;

public class KcRatingDatabaseRepository : IKcRatingRepository
{
    private readonly KnowledgeComponentsContext _dbContext;

    public KcRatingDatabaseRepository(KnowledgeComponentsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public KnowledgeComponentRating Create(KnowledgeComponentRating rating)
    {
        _dbContext.KnowledgeComponentRatings.Add(rating);
        return rating;
    }

    public List<KnowledgeComponentRating> GetByKcs(List<int> kcIds)
    {
        return _dbContext.KnowledgeComponentRatings
            .Where(r => kcIds.Contains(r.KnowledgeComponentId))
            .ToList();
    }
}