using Tutor.LearningUtils.Core.Domain;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningUtils.Infrastructure.Database.Repositories;

public class FeedbackDatabaseRepository : IFeedbackRepository
{
    private readonly LearningUtilsContext _dbContext;

    public FeedbackDatabaseRepository(LearningUtilsContext dbContext)
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