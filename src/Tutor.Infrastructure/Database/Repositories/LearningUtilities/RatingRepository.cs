using Tutor.Core.Domain.LearningUtilities;

namespace Tutor.Infrastructure.Database.Repositories.LearningUtilities;

public class RatingRepository : IRatingRepository
{
    private readonly TutorContext _dbContext;

    public RatingRepository(TutorContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void RateKnowledgeComponent(KnowledgeComponentRating knowledgeComponentRating)
    {
        _dbContext.Attach(knowledgeComponentRating);
    }
}