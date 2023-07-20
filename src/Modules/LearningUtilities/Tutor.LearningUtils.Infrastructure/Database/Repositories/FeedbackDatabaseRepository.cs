using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Infrastructure.Database.Repositories;

public class FeedbackDatabaseRepository : IFeedbackRepository
{
    private readonly LearningUtilitiesContext _dbContext;

    public FeedbackDatabaseRepository(LearningUtilitiesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveEmotionsFeedback(EmotionsFeedback emotionsFeedback)
    {
        _dbContext.EmotionsFeedbacks.Attach(emotionsFeedback);
    }

    public void SaveTutorImprovementFeedback(ImprovementFeedback tutorImprovementFeedback)
    {
        _dbContext.ImprovementFeedbacks.Attach(tutorImprovementFeedback);
    }
}