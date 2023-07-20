using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Infrastructure.Database.Repositories;

public class RatingDatabaseRepository : IRatingRepository
{
    private readonly LearningUtilitiesContext _dbContext;

    public RatingDatabaseRepository(LearningUtilitiesContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void RateKnowledgeComponent(KnowledgeComponentRating knowledgeComponentRating)
    {
        _dbContext.Attach(knowledgeComponentRating);
    }
}